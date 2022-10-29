using APC.DAL.Repositories;

namespace APC.WebUI.Configuration
{
    public static class DalRepositoryConfiguration
    {
        public static IServiceCollection AddDalRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<ISimilarProductsRepository, SimilarProductsRepository>();
            services.AddTransient<IAreasOfApplicationRepository, AreasOfApplicationRepository>();
            services.AddTransient<IProductAttributeValueRepository, ProductAttributeValueRepository>();
            services.AddTransient<IProductAttributeRepository, ProductAttributeRepository>();
            services.AddTransient<ICompatibleProductsRepository, CompatibleProductsRepository>();
            services.AddTransient<ICartProductRepository, CartProductRepository>();
            services.AddTransient<ICartRepository, CartRepository>();

            return services;
        }
    }
}
