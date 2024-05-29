using Microsoft.EntityFrameworkCore;
using SqlServerContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Entities;
using Unik.Domain.Ínterfaces;
using Unik.Domain.ValueObjects;

namespace Unik.Infrastructure.DomainServices
{
   
public class BookingDomainService : IBookingDomainService
    {
        private readonly BackendDbContext _context;

        public BookingDomainService(BackendDbContext context)
        {
            _context = context;
        }

        public bool BookingExistsOnDate(DateTime date, Item item)
        {
            return _context.Bookings
               .Include(b => b.Item) // Item
               .AsNoTracking() 
               .Any(a => a.StartDate <= date && a.EndDate >= date && a.Item.Id == item.Id);
        }
    }

}
