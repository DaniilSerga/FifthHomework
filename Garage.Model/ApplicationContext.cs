using Microsoft.EntityFrameworkCore;
using Garage.Model.DatabaseModels;
using Garage.Parser;

namespace Garage.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}