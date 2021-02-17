using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Server.Data;
using TimeSheetApp.Server.Services.Interfaces;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Server.Services.Services
{
    public class UserServices : IUser
    {
        private readonly DatabaseContext _context;
        public UserServices(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                _context.SaveChanges();
                return user;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<string> DeleteUser(int? id)
        {
            User roleToDelete = await GetUserByID(id);
            if (roleToDelete == null)
            {
                return null;
            }
            else
            {
                _context.Users.Remove(roleToDelete);
                await _context.SaveChangesAsync();
                return "User deleted successfully";
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public int GetLastUserId()
        {
            User lastUser = _context.Users
                .OrderByDescending(t => t.ID)
                .First();
            return lastUser.ID;
        }

        public async Task<User> GetUserByID(int? id)
        {
            User user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public void UpdateUser(User user)
        {
            var local = _context.Set<User>()
                   .Local
                   .FirstOrDefault(entry => entry.ID.Equals(user.ID));

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(user).State = EntityState.Modified;

            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}

