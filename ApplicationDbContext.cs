using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
   }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // one-to-many relationship between Customer and SupportTickets
    modelBuilder.Entity<Customer>()
        .HasMany(c => c.SupportTickets)
        .WithOne(t => t.Customer)
        .HasForeignKey(t => t.CustomerId);

    // relationship between Service and SupportTickets
    modelBuilder.Entity<Service>()
        .HasMany(s => s.SupportTickets)
        .WithOne(t => t.Service)
        .HasForeignKey(t => t.ServiceId)
        .IsRequired(false);
}
