using System.ComponentModel.DataAnnotations;

namespace Unik.Domain.ValueObjects
{
    /// <summary>
    /// Item er et value object, som er en del af en booking. kendetegnet ved description.
    /// </summary>
    public class Item //Item kunne godt være et value object.
    {

        public int Id { get; set; }
        //public string ImageUrl { get; set; }
        //public List<Booking> Bookings { get; set; }
        public string? Damage { get; set; } //Skal være nullable, da det ikke er sikkert at der er sket skade på et item.
        public string Description { get; set; }
        //Det er ikke hensigten at vi skal lave mange Items så vi behøver ikke at bruge så meget concurrency kontrol. så ingen rowversion.

        public Item()
        {
            //EF
        }
        public Item(string description)
        {
            Description = description;
        }

        public void Edit(string description, string damage)
        {
            Description = description;
            Damage = damage;
        }
    }
}
