using APC.WebUI.Services;

namespace APC.WebUI.Configuration
{
    public static class DalServiceConfiguration
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<IFileUploadService, AzureBlobFileUploadService>();
            services.AddTransient<ISimilarProductsService, SimilarProductsService>();
            services.AddTransient<IAreasOfApplicationService, AreasOfApplicationService>();
            services.AddTransient<IProductAttributeValueService, ProductAttributeValueService>();
            services.AddTransient<IProductAttributeService, ProductAttributeService>();
            services.AddTransient<IBrochureUploadService, BrochureUploadService>();
            services.AddTransient<ICompatibleProductsService, CompatibleProductsService>();
            services.AddTransient<ICartProductService, CartProductService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IAccountProductService, AccountProductService>();
            
            return services;
        }
    }
}
