using Assignment02.Models;
using AutoMapper;
using DAL.Entities;

namespace Assignment02.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
