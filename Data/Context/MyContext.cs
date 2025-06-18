using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore; 

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<BookEntity> Categories { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookEntity>(new BookMap().Configure);
        }
    }
}
