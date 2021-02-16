using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Client.Services.Interfaces
{
    public interface IRole
    {
        List<Role> Roles { get; set; }
        Task LoadRoles();
    }
}
