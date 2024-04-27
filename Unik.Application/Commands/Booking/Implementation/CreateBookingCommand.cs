using Shared;
using System.Data;
using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Repositories;
using Unik.Application.Repository;
using Unik.Domain.DomainServices;
using Unik.Domain.ValueObjects;

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
               
                var itemResult = _itemRepository.Load(dto.Item.Id);
                
                var booking = new Domain.Entities.Booking(itemResult, dto.StartDate, dto.EndDate)
                {
                    UserId = dto.UserId,

                };


                _bookingRepository.AddBooking(booking);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                Console.WriteLine(ex.ToString()); //Har fejl. Så bruger til at se hvad der sker
                throw;
            }
        }
    }
}
