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

            //var dbIds = product.ProductAttributesValues.Select(aoa => aoa.Id).ToArray();
            //var selectedIds = productAttributeValues.Select(aoa => aoa.Id).ToArray();
            //var ignoreIntersectIds = dbIds.Intersect(selectedIds).ToArray();

            //var removeExceptIds = dbIds.Except(selectedIds).ToArray();
            //foreach (var aoaId in removeExceptIds)
            //{
            //    var pavToRemove = product.ProductAttributesValues.FirstOrDefault(aoa => aoa.Id == aoaId);
            //    product.ProductAttributesValues.Remove(pavToRemove);
            //}

            //var addExceptIds = selectedIds.Except(dbIds).ToArray();
            //foreach (var aoaId in addExceptIds)
            //{
            //    var pavToAdd = productAttributeValues.FirstOrDefault(aoa => aoa.Id == aoaId);
            //    product.ProductAttributesValues.Add(pavToAdd);
            //}
            
            await dbContext.SaveChangesAsync();
        }
    }
}
