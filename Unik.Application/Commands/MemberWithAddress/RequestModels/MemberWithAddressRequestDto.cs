namespace Unik.Application.Commands.MemberWithAddress.RequestModels
{
    public class MemberWithAddressRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
