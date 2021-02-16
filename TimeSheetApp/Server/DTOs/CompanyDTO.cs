using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Server.DTOs
{
    public class CompanyDTO
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Organization { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        //public IList<Project> Projects { get; set; }
    }
}
