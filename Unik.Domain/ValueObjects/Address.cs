namespace Unik.Domain.ValueObjects
{
    public class Address // ValueObject, immutable, skal ikke kunne ændres efter oprettelse. Id er til EF.
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
