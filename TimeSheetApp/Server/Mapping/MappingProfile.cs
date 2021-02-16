using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TimeSheetApp.Server.DTOs;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Server.Mapping
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            //CreateMap<RoleDTO, Role>().ReverseMap();
            CreateMap<User, User>().ReverseMap();
            CreateMap<Role, Role>().ReverseMap();
            CreateMap<Company, Company>().ReverseMap();
            CreateMap<Timesheet, Timesheet>().ReverseMap();
            CreateMap<Project, Project>().ReverseMap();
            CreateMap<TimesheetUser, TimesheetUser>().ReverseMap();
            CreateMap<UserProject, UserProject>().ReverseMap();
        }
    }
}
