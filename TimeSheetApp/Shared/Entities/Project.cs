﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetApp.Shared.Entities
{
    public class Project
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreate { get; set; }
        public IList<UserProject> UserProjects { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }

    }
}
