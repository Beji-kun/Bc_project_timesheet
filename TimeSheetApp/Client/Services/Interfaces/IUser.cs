using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Client.Services.Interfaces
{
    public interface IUser
    {
        List<User> Users { get; set; }
        Task LoadUsers();
    }
}
