using Unik.Application.Commands.MemberWithAddress.RequestModels;

namespace Unik.Application.Queries.MemberWithAddress.DTO
{
    public class MemberWithAddressQueryResultDto
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public GetAddressQueryResultDto Address { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}