using Microsoft.EntityFrameworkCore;
using SanaWebTest.Storage.Entities;
using System.Configuration;

namespace SanaWebTest.Storage.EFSqlServer
{

    /// <summary>
    /// Implementation of a DbContext for Entity Framework
    /// </summary>
    public class SanaTestDbContext : DbContext
    {
        //private readonly IConfiguration _confituration;

        public SanaTestDbContext(DbContextOptions<SanaTestDbContext> options) : base(options)
        {

        }

        //public SanaTestDbContext(IConfiguration configuration) : base()
        //{
        //    _confituration = configuration;
        //}

        public SanaTestDbContext() : base() { }



        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Category>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_confituration.GetConnectionString("SqlServerDefault"));
        //}

    }
}
