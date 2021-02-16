using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Server.Data;
using TimeSheetApp.Server.Interfaces;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Server.DTOs
{
    public class RoleDTO : IRole
    {
        private readonly DatabaseContext _context;
        public RoleDTO(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Role> CreateRole(Role role)
        {
            try
            {
                await _context.Roles.AddAsync(role);
                _context.SaveChanges();
                return role;
            }
            catch 
            { 
                throw new NotImplementedException();
            }
        }

        public async Task<string> DeleteRole(int? id)
        {
            Role roleToDelete = await GetRoleByID(id);
            if (roleToDelete == null)
            {
                return null;
            }
            else
            {
                _context.Roles.Remove(roleToDelete);
                await _context.SaveChangesAsync();
                return "Role deleted successfully";
            }
        }

        public List<Role> GetAllRoles()
        {
            try
            {
                return _context.Roles.ToList();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public int GetLastRoleId()
        {
            Role lastRole = _context.Roles
                .OrderByDescending(t => t.ID)
                .First();
            return lastRole.ID;
        }

        public async Task<Role> GetRoleByID(int? id)
        {
            Role role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return null;
            }
            return role;
        }

        public void UpdateRole(Role role)
        {
            var local = _context.Set<Role>()
                   .Local
                   .FirstOrDefault(entry => entry.ID.Equals(role.ID));

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(role).State = EntityState.Modified;

            _context.Roles.Update(role);
            _context.SaveChanges();
        }
    }
}

