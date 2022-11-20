using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace APC.DAL.Repositories
{
    public class ProductAttributeValueRepository : IProductAttributeValueRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public ProductAttributeValueRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task SaveAsync(int productId, IEnumerable<ProductAttributeValue> productAttributeValues)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var product = dbContext.Products
                .Include(p => p.ProductAttributesValues)
                .FirstOrDefault(p => p.Id == productId);

            product.ProductAttributesValues = productAttributeValues.ToList();

            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(ProductAttributeValue productAttributeValue)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            //var productAttributeValue = dbContext.ProductAttributeValue
            //    .FirstOrDefault(pav => pav.Id == productAttributeValueId);
            //if (productAttributeValue is null)
            //{
            //    throw new Exception("invalid product attribute value id");
            //}

            //dbContext.ProductAttributeValue.Attach(productAttributeValue);
            try
            {
                dbContext.Attach(productAttributeValue); 
                dbContext.Remove(productAttributeValue);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                var msg = e.Message;
            }
        }
    }
}
