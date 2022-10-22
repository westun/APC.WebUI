using APC.DAL.DataAccess;
using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APC.DAL.Repositories
{
    public class AreasOfApplicationRepository : IAreasOfApplicationRepository
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public AreasOfApplicationRepository(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<AreasOfApplication>> GetAsync()
        {
            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();

            return await dbContext.AreasOfApplication.ToListAsync();
        }

        public async Task Save(int productId, IEnumerable<AreasOfApplication> areasOfApplications)
        {
            if (areasOfApplications is null)
            {
                throw new ArgumentNullException(nameof(areasOfApplications));
            }

            using var dbContext = await this.dbContextFactory.CreateDbContextAsync();

            var product = dbContext.Products
                .Include(p => p.AreasOfApplications)
                .FirstOrDefault(p => p.Id == productId);
            if (product is null)
            {
                throw new Exception("Product not found by Id");
            }

            var dbIds = product.AreasOfApplications.Select(aoa => aoa.Id).ToArray();
            var selectedIds = areasOfApplications.Select(aoa => aoa.Id).ToArray();
            var ignoreIntersectIds = dbIds.Intersect(selectedIds).ToArray();

            var removeExceptIds = dbIds.Except(selectedIds).ToArray();
            foreach (var aoaId in removeExceptIds)
            {
                var aoaToRemove = product.AreasOfApplications.FirstOrDefault(aoa => aoa.Id == aoaId);
                product.AreasOfApplications.Remove(aoaToRemove);
            }

            var addExceptIds = selectedIds.Except(dbIds).ToArray();
            foreach (var aoaId in addExceptIds)
            {
                var aoaToAdd = areasOfApplications.FirstOrDefault(aoa => aoa.Id == aoaId);
                product.AreasOfApplications.Add(aoaToAdd);
            }

            dbContext.SaveChanges();
        }
    }
}
