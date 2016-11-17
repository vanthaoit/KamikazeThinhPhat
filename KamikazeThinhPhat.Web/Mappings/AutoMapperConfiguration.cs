using AutoMapper;
using KamikazeThinhPhat.Model.Models;
using KamikazeThinhPhat.Web.Models;

namespace KamikazeThinhPhat.Web.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
        }
    }
}