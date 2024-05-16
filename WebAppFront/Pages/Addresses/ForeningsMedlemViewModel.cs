namespace WebAppFront.Pages.Addresses
{
    public class ForeningsMedlemViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressViewModel? Address { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string? CreatedBy { get; set; } 
        public DateTime? LastModifiedDate { get; set; }
    }
}
