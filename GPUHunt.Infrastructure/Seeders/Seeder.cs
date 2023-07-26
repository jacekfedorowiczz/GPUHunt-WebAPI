using GPUHunt.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly GPUHuntDbContext _dbContext;

        public Seeder(GPUHuntDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Seed the database with initial data
        /// </summary>
        /// <returns></returns>
        public async Task SeedDatabase()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Stores.Any())
                {
                    var stores = GetStores();
                    await _dbContext.Vendors.AddRangeAsync(stores);
                    await _dbContext.SaveChangesAsync();
                }
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    await _dbContext.Roles.AddRangeAsync(roles);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Returns collection of initial roles for accounts
        /// </summary>
        /// <returns></returns>
        private IEnumerable<GPUHunt.Domain.Entities.Role> GetRoles()
        {
            var roles = new List<GPUHunt.Domain.Entities.Role>()
            {
                new Domain.Entities.Role()
                {
                    Name = "User",
                    Description = "Basic role for new accounts"
                },
                new Domain.Entities.Role()
                {
                    Name = "Admin",
                    Description = "Administrator of Web API"
                },
            };

            return roles;
        }

        /// <summary>
        /// Returns initial collection of stores 
        /// </summary>
        /// <returns></returns>
        private IEnumerable<GPUHunt.Domain.Entities.Vendor> GetStores()
        {
            var vendors = new List<GPUHunt.Domain.Entities.Vendor>()
            {
                new Domain.Entities.Vendor()
                {
                    Name = "Morele"
                },
                new Domain.Entities.Vendor()
                {
                    Name = "X-Kom"
                },
            };

            return vendors;
        }


    }
}
