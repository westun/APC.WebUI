using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public ProductAttributeRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<ProductAttribute>> GetAsync()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.ProductAttribute
                .OrderBy(a => a.Name)
                .ToListAsync();
        }

        public async Task<ProductAttribute> SaveAsync(ProductAttribute productAttribute)
        {
            if (productAttribute is null)
            {
                throw new ArgumentNullException(nameof(productAttribute));
            }

            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var attribute = dbContext.ProductAttribute
                .FirstOrDefault(a => a.Id == productAttribute.Id);
            var createNew = attribute is null;
            if (createNew)
            {
                dbContext.ProductAttribute.Add(productAttribute);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                //update existing
            }

            return productAttribute;
        }
    }
}
