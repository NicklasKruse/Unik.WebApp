using Shared;
using System.Data;
using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Repository;

namespace Unik.Application.Commands.Booking.Implementation
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookingCommand(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
        {
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
        }
        void ICreateBookingCommand.CreateBooking(BookingCreateRequestDto dto)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                var booking = new Domain.Entities.Booking(dto.Items, dto.StartDate, dto.EndDate);
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
