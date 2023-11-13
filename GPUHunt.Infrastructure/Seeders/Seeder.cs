using GPUHunt.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

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
        public void SeedDatabase()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Stores.Any())
                {
                    var stores = GetStores();
                    _dbContext.Stores.AddRange(stores);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Returns collection of initial roles for accounts
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Domain.Entities.Role> GetRoles()
        {
            var roles = new List<Domain.Entities.Role>()
            {
                new Domain.Entities.Role()
                {
                    Name = "User",
                    Description = "Basic role for new accounts"
                },
                new Domain.Entities.Role()
                {
                    Name = "Admin",
                    Description = "Administrator"
                },
                new Domain.Entities.Role()
                {
                    Name = "Moderator",
                    Description = "Moderator"
                }
            };

            return roles;
        }

        /// <summary>
        /// Returns initial collection of stores 
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Domain.Entities.Store> GetStores()
        {
            var vendors = new List<Domain.Entities.Store>()
            {
                new Domain.Entities.Store()
                {
                    Name = "Morele"
                },
                new Domain.Entities.Store()
                {
                    Name = "X-Kom"
                },
            };

            return vendors;
        }
    }
}
