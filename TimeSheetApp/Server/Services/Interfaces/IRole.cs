using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Server.Services.Interfaces
{
    public interface IRole
    {
        //List<Role> GetAllRoles();
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleByID(int? id);
        Task<Role> CreateRole(Role role);
        int GetLastRoleId();
        void UpdateRole(Role role);

        Task<string> DeleteRole(int? id);
        
    }
}
