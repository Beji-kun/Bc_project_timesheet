using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetApp.Shared.Entities
{
    public class Timesheet
    {
        public Timesheet()
        {
            this.Users = new HashSet<User>();
            this.Projects = new HashSet<Project>();
        }
        [Key]
        public int ID { get; set; }
        public string Notes { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalHours { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}