using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public ProductTypeRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<ProductType>> GetAsync()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.ProductTypes
                .Include(pt => pt.Category)
                .ToListAsync();
        }

        public async Task<ProductType> Save(ProductType productType)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var productTypeFromDB = dbContext.ProductTypes.FirstOrDefault(pt => pt.Id == productType.Id);
            if (productTypeFromDB is null)
            {
                dbContext.ProductTypes.Add(productType);
                dbContext.SaveChanges();

                return productType;
            }

            //update existing product type
            throw new NotImplementedException();

            return productType;
        }   
    }
}
