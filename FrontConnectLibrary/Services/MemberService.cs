using FrontConnectLibrary.Interfaces;
using FrontConnectLibrary.Models.Member;
using System.Net.Http.Json;

namespace FrontConnectLibrary.Services
{
    public class MemberService : IMemberService
    {
        private readonly HttpClient _httpClient;
        public MemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        async Task IMemberService.CreateMember(MemberCreateRequestDto memberRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Member/create", memberRequest);
            if(response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to create member");
            }
        }

        async Task IMemberService.DeleteMember(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Member/delete/{id}");
            if(response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to delete member");
            }
        }

        async Task IMemberService.EditMember(MemberEditRequestDto memberRequest)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Member/edit", memberRequest);
            if(response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Failed to edit member");
            }
        }

        async Task<IEnumerable<MemberQueryResultDto>?> IMemberService.GetAllMember()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MemberQueryResultDto>>("api/Member"); //Possible null, så har "?" efter IEnumerable<MemberQueryResultDto>
        }

        async Task<MemberQueryResultDto> IMemberService.GetMemberById(int id)
        {
           return await _httpClient.GetFromJsonAsync<MemberQueryResultDto>($"api/Member/{id}");
        }
    }
}
