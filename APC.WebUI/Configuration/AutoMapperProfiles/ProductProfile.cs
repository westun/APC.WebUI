using APC.DAL.Models;
using APC.WebUI.Models;
using AutoMapper;

namespace APC.WebUI.Configuration.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductDTO>()
                .ReverseMap();

            this.CreateMap<ProductCategory, ProductCategoryDTO>()
                .ReverseMap();

            this.CreateMap<ProductType, ProductTypeDTO>()
                .ReverseMap();

            this.CreateMap<ProductAttributeValue, ProductAttributeValueDTO>()
                .ReverseMap();

            this.CreateMap<AreasOfApplication, AreasOfApplicationDTO>()
                .ReverseMap();

            this.CreateMap<ProductAttribute, ProductAttributeDTO>()
                .ReverseMap();

            this.CreateMap<SimilarProducts, SimilarProductsDTO>()
                .ReverseMap();

            this.CreateMap<CompatibleProducts, CompatibleProductsDTO>()
                .ReverseMap();

            this.CreateMap<Account, AccountDTO>()
                .ReverseMap();

            this.CreateMap<Cart, CartDTO>()
                .ReverseMap();

            this.CreateMap<CartProduct, CartProductDTO>()
                .ReverseMap();

            this.CreateMap<Order, OrderDTO>()
                .ReverseMap();

            this.CreateMap<OrderItem, OrderItemDTO>()
                .ReverseMap();
        }
    }
}
