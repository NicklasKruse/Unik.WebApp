namespace WebAppFront.Pages.Invitations
{
    public class CreateInvitationViewModel
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
