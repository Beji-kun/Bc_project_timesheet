using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Shared.Entities;
using TimeSheetApp.Client.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using TimeSheetApp.Client.Pages;

namespace TimeSheetApp.Client.Services.Services
{
    public class RoleServices : IRole
    {
        private readonly HttpClient _http;
        public List<Role> Roles { get; set; } = new List<Role>();
        public RoleServices(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadRoles()
        {
            Roles = await _http.GetFromJsonAsync<List<Role>>("api/Role");
        }
    }
}
