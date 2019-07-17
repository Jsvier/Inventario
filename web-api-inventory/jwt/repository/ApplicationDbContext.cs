using api_inventory.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace web_api_inventory.jwt.repository {
    public class ApplicationDbJWTContext : IdentityDbContext<AppUser> {
        public ApplicationDbJWTContext (DbContextOptions options) : base (options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Partner> Partners { get; set; }
    }
}