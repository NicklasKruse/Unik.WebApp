using FrontConnectLibrary.Interfaces;
using FrontConnectLibrary.Models;
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

        Task IMemberService.DeleteMember(int id)
        {
            throw new NotImplementedException();
        }
    }
}
