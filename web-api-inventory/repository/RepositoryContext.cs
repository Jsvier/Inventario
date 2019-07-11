using api_inventory.Models;
using Microsoft.EntityFrameworkCore;
 
namespace web_api_inventory.repository
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
        }
 
        public DbSet<User> Users { get; set; }
    }
}
