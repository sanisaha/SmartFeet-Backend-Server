using Ecommerce.Domain.src.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.src.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring("");
        }
    }
}