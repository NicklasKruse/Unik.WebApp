using Shared;
using System.Data;
using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Repositories;
using Unik.Application.Repository;
using Unik.Domain.Ínterfaces;

namespace Unik.Application.Commands.Booking.Implementation
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IBookingDomainService _bookingDomainService;
        private readonly IBookingRepository _bookingRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingCommand(IBookingRepository bookingRepository, IItemRepository itemRepository, IUnitOfWork unitOfWork, IBookingDomainService bookingDomainService)
        {
            _bookingRepository = bookingRepository;
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
            _bookingDomainService = bookingDomainService;

        }
        void ICreateBookingCommand.CreateBooking(BookingCreateRequestDto dto)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
               
                var itemResult = _itemRepository.Load(dto.ItemId);
                
                var booking = new Domain.Entities.Booking(itemResult, dto.StartDate, dto.EndDate, _bookingDomainService)
                {
                    UserId = dto.UserId,
                    CreatedBy = dto.CreatedBy,
                    DateOfCreation = dto.DateOfCreation
                };


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
