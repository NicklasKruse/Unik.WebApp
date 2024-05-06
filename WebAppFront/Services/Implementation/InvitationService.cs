namespace WebAppFront.Services.Implementation
{
    public class InvitationService
    {
        private readonly HttpClient _httpClient;

        public InvitationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
