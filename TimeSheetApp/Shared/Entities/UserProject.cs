using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetApp.Shared.Entities
{
    public class UserProject
    {
        public int UserID { get; set; }
        public User Users;
        public int ProjectID { get; set; }
        public Project Projects { get; set; }
    }
}
