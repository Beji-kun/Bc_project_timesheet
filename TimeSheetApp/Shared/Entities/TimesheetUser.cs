using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetApp.Shared.Entities
{
    public class TimesheetUser
    {
        public int UserID { get; set; }
        public User Users;
        public int TimeSheetID { get; set; }
        public Timesheet Timesheets { get; set; }
    }
}
