using AutoMapper;
using ICAO.IEDF.Core.Domain;
using ICAO.IEDF.Web.Models;

namespace ICAO.IEDF.Web
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<MyProfile>());
        }
    }

    public class MyProfile : Profile
    {
        protected override void Configure()
        {
            CreateMaps();
        }

        private static void CreateMaps()
        {
            Mapper.CreateMap<Feedback, FeedbackModel>();
            Mapper.CreateMap<Order, OrderModel>();
            Mapper.CreateMap<Product, ProductModel>();
            Mapper.CreateMap<Product, ProductEditModel>();
            Mapper.CreateMap<Product, ProductSimpleModel>();
            Mapper.CreateMap<Product, ProductDashboardModel>();
            Mapper.CreateMap<Product, ProductCartModel>();
            Mapper.CreateMap<ProductDetail, ProductDetailModel>();
            Mapper.CreateMap<ShoppingCart, ShoppingCartModel>();
            Mapper.CreateMap<ShoppingCartItem, ShoppingCartItemModel>();
        }
    }
}