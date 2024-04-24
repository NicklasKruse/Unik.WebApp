using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Models;

namespace Unik.Domain.Ínterfaces
{
    public interface IBookingDomainService
    {
        bool BookingOverlap(DateTime date);
    }
}
