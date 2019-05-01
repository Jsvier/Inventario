using Microsoft.EntityFrameworkCore;

namespace razor_inventory.DAL
{
    public class ApplicatinDbContext:DbContext
    {
     public DbSet<Customer> Customers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle(@"User Id=Scott;Password=tiger;Data Source=Ora;");
    } 
    }
}