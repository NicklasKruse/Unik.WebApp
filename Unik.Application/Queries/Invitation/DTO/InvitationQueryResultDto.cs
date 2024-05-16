namespace Unik.Application.Queries.Invitation.DTO
{
    public class InvitationQueryResultDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public byte[] RowVersion { get; set; }
        public string CreatedBy { get; set; }
        //public List<InvitationAcceptanceQueryResultDto> Acceptances { get; set; } = new List<InvitationAcceptanceQueryResultDto>();
    }
}
