using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public ProductRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<Product> GetAsync(int id)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Type)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Type)
                .Include(p => p.ProductAttributesValues)
                .ThenInclude(pav => pav.ProductAttribute)
                .OrderBy(p => p.Type.Name)
                .ThenBy(p => p.Name)
                .ToListAsync();
        }
    }
}
