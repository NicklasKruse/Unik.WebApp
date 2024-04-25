using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Commands.Booking
{
    public interface IDeleteBookingCommand
    {
        void Delete(int id);
    }
}
