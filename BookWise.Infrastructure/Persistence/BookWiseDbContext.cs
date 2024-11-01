using BookWise.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Persistence;

public class BookWiseDbContext : DbContext
{
    public BookWiseDbContext(DbContextOptions<BookWiseDbContext> options) : base(options) {}
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Publisher>(e =>
            {
                e.HasKey(p => p.Id);
                
                e.HasMany(p => p.Books)
                    .WithOne(b => b.Publisher)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.HasMany(u => u.Ratings)
                    .WithOne(r => r.User)
                    .HasForeignKey(r => r.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Book>(e =>
            {
                e.HasKey(b => b.Id);
                
                e.HasMany(b => b.Ratings)
                    .WithOne(r => r.Book)
                    .HasForeignKey(l => l.IdBook)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Loan>(e =>
            {
                e.HasKey(l => l.Id);
                
                e.HasOne(l => l.User)
                    .WithMany(u => u.Loans)
                    .HasForeignKey(l => l.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(l => l.Book)
                    .WithMany(b => b.Loans)
                    .HasForeignKey(l => l.BookId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Notification>(e =>
            {
                e.HasKey(n => n.Id);

                e.HasOne(n => n.User)
                    .WithMany(u => u.Notifications)
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.Property(n => n.Content)
                    .IsRequired()
                    .HasMaxLength(600);
            });
    }
}