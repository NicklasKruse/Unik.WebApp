using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Entities;
using Unik.Domain.Ínterfaces;


namespace Unik.Domain.ValueObjects
{
    public class Item //Item kunne godt være et value object.
    {

        public int Id { get; set; }
        //public string ImageUrl { get; set; }
        //public List<Booking> Bookings { get; set; }
        public string? Damage { get; set; }
        public string Description { get; set; }
        List<Booking> bookings { get; set; }

    }
}
