using AutoMapper;
using KamikazeThinhPhat.Model.Models;
using KamikazeThinhPhat.Web.Models;

namespace KamikazeThinhPhat.Web.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Slide, SlideViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Post, PostViewModel>();
        }
    }
}