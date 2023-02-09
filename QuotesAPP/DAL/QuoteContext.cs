using System;
using Microsoft.EntityFrameworkCore;

namespace QuotesAPP.DAL
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options)
        {
        }

        public QuoteContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Data Source=QouteDB.db";
                if (!optionsBuilder.IsConfigured)
                   optionsBuilder.UseSqlite(conn);
        }
            
                

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(b => b.CreatedAt)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Quote>()
                .Property(b => b.CreatedAt)
                .HasDefaultValue(DateTime.Now);
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Quote> Quotes { get; set; }
    }
}

