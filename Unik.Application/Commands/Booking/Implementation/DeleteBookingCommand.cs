using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Repository;

namespace Unik.Application.Commands.Booking.Implementation
{
    public class DeleteBookingCommand : IDeleteBookingCommand
    {
        private readonly IBookingRepository _bookingRepository;
        public DeleteBookingCommand(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        void IDeleteBookingCommand.Delete(int id)
        {
            var model = _bookingRepository.Load(id);
            if (model == null)
            {
                throw new Exception("Booking not found");
            }
            _bookingRepository.DeleteBooking(model);

        }
    }
}
