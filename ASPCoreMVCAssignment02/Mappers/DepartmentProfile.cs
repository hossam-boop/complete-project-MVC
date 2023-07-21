using Assignment02.Models;
using AutoMapper;
using DAL.Entities;

namespace Assignment02.Mappers
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap(); 
        }
    }
}
