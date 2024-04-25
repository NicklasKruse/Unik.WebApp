using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Domain.Ínterfaces
{
    public interface IBookingDomainService
    {
        bool BookingOverlap(DateTime date);
    }
}
