using AutoMapper;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
namespace NorthwndApp.MvcWebUI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<SupplierAddDto, Supplier>().ReverseMap();
            CreateMap<EmployeeAddDto, Employee>().ReverseMap();
            CreateMap<CustomerAddDto, Customer>().ReverseMap();
            CreateMap<MusterilerAddDto, Musteriler>().ReverseMap();
            CreateMap<OrderViewModel, Order>().ReverseMap();
        }
    }
}
