﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetApp.Shared.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public DateTime LastActive { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public IList<UserProject> UserProjects;
        public IList<TimesheetUser> TimesheetUsers;
    }
}