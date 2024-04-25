using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Repository;

namespace Unik.Application.Commands.Booking.Implementation
{
    public class EditBookingCommand : IEditBookingCommand
    {
        private readonly IBookingRepository _bookingRepository;

        public EditBookingCommand(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        void IEditBookingCommand.Edit(BookingEditRequestDto dto)
        {
            var model = _bookingRepository.Load(dto.Id);
            if (model == null)
            {
                throw new Exception("Booking not found");
            }
            model.Edit(dto.Items, dto.StartDate, dto.EndDate);
            _bookingRepository.UpdateBooking(model);
        }
    }
}
