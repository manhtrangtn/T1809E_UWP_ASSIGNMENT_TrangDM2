using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Models;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Utils;

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements
{
    class MemberService: IMemberService
    {
        private readonly HttpClient httpClient = new HttpClient();
        public async Task<String> Login(string email, String password)
        {
            JObject loginData = new JObject
            {
                ["email"] = email,
                ["password"] = password
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, Constants.JSON_CONTENT_TYPE);
            var resp = await httpClient.PostAsync(Constants.LOGIN_URL, content);

            return await resp.Content.ReadAsStringAsync();
        }

        public async Task<string> Register(Member member)
        {
            var jsonData = JsonConvert.SerializeObject(member);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, Constants.JSON_CONTENT_TYPE);
            var response = await httpClient.PostAsync(Constants.REGISTER_URL, content);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<String> GetMemberInformation(String token)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, Constants.GETMEMBER_URL);
            httpRequestMessage.Headers.Add("Authorization", token);
            var resp = await httpClient.SendAsync(httpRequestMessage);
            return await resp.Content.ReadAsStringAsync();
        }


    }
}
