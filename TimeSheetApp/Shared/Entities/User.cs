using System;
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
        public User()
        {
            this.Projects = new HashSet<Project>();
            this.Timesheets = new HashSet<Timesheet>();
        }
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
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Timesheet> Timesheets { get; set; }
        public Role Role { get; set; }
    }
}