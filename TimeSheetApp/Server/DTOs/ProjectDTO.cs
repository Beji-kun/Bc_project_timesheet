using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Server.DTOs
{
    public class ProjectDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreate { get; set; }
        //public IList<UserProject> UserProjects { get; set; }
        public int CompanyID { get; set; }
        public CompanyDTO Company { get; set; }
    }
}
