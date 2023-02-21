using AutoMapper;
using ProductManagementWebAPI.DTO;
using ProductManagementWebAPI.Models;

namespace ProductManagementApi.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Products, ProductDto>().ReverseMap();
            CreateMap<Catagories, CatagoryDto>().ReverseMap();
        }


    }
}
