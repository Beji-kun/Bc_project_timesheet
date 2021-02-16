using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Server.Services.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByID(int? id);
        Task<User> CreateUser(User user);
        int GetLastUserId();
        void UpdateUser(User user);

        Task<string> DeleteUser(int? id);

    }
}
