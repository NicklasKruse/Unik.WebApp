namespace WebAppFront.Services.Models.Addresses
{
    public class AddressCreateRequestDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
