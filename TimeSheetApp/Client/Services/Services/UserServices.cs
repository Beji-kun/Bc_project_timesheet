using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Client.Services.Services
{
    public class UserServices
    {
        private readonly HttpClient _http;
        public List<User> Users { get; set; } = new List<User>();
        public UserServices(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadRoles()
        {
            Users = await _http.GetFromJsonAsync<List<User>>("api/User");
        }
    }
}
