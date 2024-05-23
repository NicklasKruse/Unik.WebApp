using System.Net;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Models.Invitation;

namespace WebAppFront.Services.Implementation
{
    /// <summary>
    /// Service til håndtering af invitationer
    /// </summary>
    public class InvitationService : IInvitationService
    {
        private readonly HttpClient _httpClient;

        public InvitationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IInvitationService.CreateInvitation(InvitationCreateRequestDto invitationRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Invitation/create", invitationRequest);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound) 
            {
                throw new Exception("Endpoint not found");
            }
            else
            {
                throw new Exception("Failed to create invitation");
            }
        }

        async Task IInvitationService.DeleteInvitation(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Invitation/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to delete invitation");
            }
        }

        async Task IInvitationService.EditInvitation(InvitationEditRequestDto invitationRequest)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Invitation/edit", invitationRequest);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to edit invitation");
            }
        }

        async Task<IEnumerable<InvitationQueryResultDto>?> IInvitationService.GetAllInvitation()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<InvitationQueryResultDto>>("api/Invitation/getall");
        }

        async Task<InvitationQueryResultDto> IInvitationService.GetInvitationById(int id)
        {
            return await _httpClient.GetFromJsonAsync<InvitationQueryResultDto>($"api/Invitation/get/{id}");
        }
    }
}
