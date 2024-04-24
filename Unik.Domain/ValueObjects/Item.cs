using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Ínterfaces;
using Unik.Domain.Models;


namespace Unik.Domain.ValueObjects
{
    public class Item //Item kunne godt være et value object. Skal man kunne oprette et item uden at have en booking på det? Hvis ikke, så skal den være en entity
    {

        public int Id { get; set; }
        //public string ImageUrl { get; set; }
        //public List<Booking> Bookings { get; set; }
        public string? Damage { get; set; }
        public string Description { get; set; }
        List<Booking> bookings { get; set; }

    }
}
