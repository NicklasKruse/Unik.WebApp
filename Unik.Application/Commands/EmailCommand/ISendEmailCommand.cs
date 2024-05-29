using Unik.Application.Commands.Booking.DTO;

namespace Unik.Application.Commands.EmailCommand
{
    public interface ISendEmailCommand
    {
        Task SendToSingleUser(BookingCreateRequestDto request);
        Task SendEmailsToAllMembersAsync(string sender, string message);
    }
}
