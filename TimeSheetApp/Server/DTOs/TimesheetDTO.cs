using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Server.DTOs
{
    public class TimesheetDTO
    {
        public int ID { get; set; }
        public string Notes { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalHours { get; set; }
        //public IList<TimesheetUser> TimesheetUsers { get; set; }
        //public IList<Project> Projects { get; set; }
    }
}
