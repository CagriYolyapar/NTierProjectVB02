using AutoMapper;
using Project.Bll.Dtos;
using Project.WebApi.Models.RequestModels.Categories;
using Project.WebApi.Models.ResponseModels.Categories;

namespace Project.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();
        }
    }
}
