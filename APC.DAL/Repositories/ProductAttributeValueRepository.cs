using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class ProductAttributeValueRepository : IProductAttributeValueRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public ProductAttributeValueRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task Save(int productId, IEnumerable<ProductAttributeValue> productAttributeValues)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var product = dbContext.Products
                .Include(p => p.ProductAttributesValues)
                .FirstOrDefault(p => p.Id == productId);

            product.ProductAttributesValues = productAttributeValues.ToList();

            await dbContext.SaveChangesAsync();
        }
    }
}
