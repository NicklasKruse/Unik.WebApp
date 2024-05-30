using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Queries.MemberWithAddress;
using Unik.Application.ServiceContracts.EmailService;

namespace Unik.Application.Commands.EmailCommand
{
    public class SendEmailCommand : ISendEmailCommand
    {
        private readonly IEmailSender _emailSender;
        private readonly IGetAllMemberWithAddressQuery _getAllMemberWithAddressQuery;

        public SendEmailCommand(IEmailSender emailSender, IGetAllMemberWithAddressQuery getAllMemberWithAddressQuery)
        {
            _emailSender = emailSender;
            _getAllMemberWithAddressQuery = getAllMemberWithAddressQuery;
        }

        public async Task SendToSingleUser(BookingCreateRequestDto request)
        {
            await _emailSender.SendEmailAsync($"admin@admin.dk", $"Item: {request.ItemId}", $"Dette item {request.ItemId}, er blevet booked af afsender \r\n Tidspunkt for booking: {request.StartDate}\r\n Dette Item er til rådighed igen: {request.EndDate}", request.CreatedBy);
        }
        public async Task SendEmailsToAllMembersAsync(string sender, string message)
        {
            var members = await _getAllMemberWithAddressQuery.GetAllMemberWithAddressAsync();

            foreach (var member in members)
            {
                await _emailSender.SendEmailAsync(member.Email, "Invitation", message, sender);
            }
        }
    }
}
