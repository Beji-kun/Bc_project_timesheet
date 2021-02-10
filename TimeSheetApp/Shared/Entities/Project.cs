using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetApp.Shared.Entities
{
    public class Project
    {
        public Project()
        {
            this.Users = new HashSet<User>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreate { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
