namespace Unik.Domain.ValueObjects
{
    /// <summary>
    /// Item er et value object, som er en del af en booking. kendetegnet ved description.
    /// </summary>
    public class Item //Item kunne godt være et value object. Dog kan vi i dette tilfælde redigere og derfor er det egentlig en entity.
    {

        public int Id { get; set; }
        //public string ImageUrl { get; set; }
        //public List<Booking> Bookings { get; set; }
        public string? Damage { get; set; } //Skal være nullable, da det ikke er sikkert at der er sket skade på et item.
        public string Description { get; set; }


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
