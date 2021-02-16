using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetApp.Shared.Entities
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<User> Users { get; set; }
    }
}
