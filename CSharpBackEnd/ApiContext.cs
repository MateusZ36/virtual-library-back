using CSharpBackEnd.Domain;
using Microsoft.EntityFrameworkCore;

namespace CSharpBackEnd
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PublishingCompany> PublishingCompanies { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .HasMany(l => l.Loans)
                .WithOne(u => u.User)
                .HasForeignKey(p=> p.UserId);
        }
    }
    
}