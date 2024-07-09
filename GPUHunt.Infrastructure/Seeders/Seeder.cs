using GPUHunt.Domain.Constanst;
using GPUHunt.Domain.Enums;
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


                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Vendors.Any())
                {
                    var vendors = GetVendors();
                    _dbContext.Vendors.AddRange(vendors);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Subvendors.Any())
                {
                    var subvendors = GetSubvendors();
                    _dbContext.Subvendors.AddRange(subvendors);
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
            return new List<Domain.Entities.Role>()
            {
                new Domain.Entities.Role()
                {
                    Name = ConstValues.UserRoleName,
                    Description = ConstValues.UserRoleDescription
                },
                new Domain.Entities.Role()
                {
                    Name = ConstValues.AdminRoleName,
                    Description = ConstValues.AdminRoleDescription
                },
                new Domain.Entities.Role()
                {
                    Name = ConstValues.ModeratorRoleName,
                    Description = ConstValues.ModeratorRoleDescription
                }
            };
        }

        private IEnumerable<Domain.Entities.Vendor> GetVendors()
        {
            return new List<Domain.Entities.Vendor>()
            {
                new Domain.Entities.Vendor()
                {
                    Name = ConstValues.VendorUndefined
                },
                new Domain.Entities.Vendor()
                {
                    Name = ConstValues.VendorNVIDIA
                },
                new Domain.Entities.Vendor()
                {
                    Name = ConstValues.VendorAMD
                },
                new Domain.Entities.Vendor()
                {
                    Name = ConstValues.VendorIntel
                }
            };
        }

        private IEnumerable<Domain.Entities.Subvendor> GetSubvendors()
        {
            var values = Enum.GetValues<Subvendors>().ToList();
            var subvendors = new List<Domain.Entities.Subvendor>();

            foreach (var value in values)
            {
                subvendors.Add(new Domain.Entities.Subvendor() { Name = value.ToString() });
            }

            return subvendors;
        }
    }
}
