using AutoMapper;
using CityConnect.Business.ViewModels;
using CityConnect.Business.ViewModels.Organization;
using CityConnect.Domain;
using CityConnect.Domain.Models;

namespace CityConnect.Business.Helpers
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<RoleModuleDetailsModel, RoleModule>();
            CreateMap<RoleModule, RoleModuleDetailsModel>();
        }
    }
}