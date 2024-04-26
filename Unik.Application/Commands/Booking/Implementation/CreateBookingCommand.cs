using Shared;
using System.Data;
using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Repositories;
using Unik.Application.Repository;

namespace Unik.Application.Commands.Booking.Implementation
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookingCommand(IBookingRepository bookingRepository, IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _bookingRepository = bookingRepository;
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }
        void ICreateBookingCommand.CreateBooking(BookingCreateRequestDto dto)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                var items = new List<Domain.ValueObjects.Item>();

                foreach (var itemId in dto.ItemIds)
                {
                    var itemDto = _itemRepository.GetById(itemId); 
                    var item = new Domain.ValueObjects.Item(itemDto.Description)
                    {
                        Id = itemDto.Id,
                        Damage = itemDto.Damage
                    };

                    items.Add(item);
                }

                var booking = new Domain.Entities.Booking(items, dto.StartDate, dto.EndDate);
                _bookingRepository.AddBooking(booking);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
