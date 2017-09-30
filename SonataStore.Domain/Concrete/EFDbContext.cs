using SonataStore.Domain.Entities;
using System.Data.Entity;

namespace SonataStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
