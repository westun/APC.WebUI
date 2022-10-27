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

            return services;
        }
    }
}
