using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityService.DBContext
{
    public class EntityDbContext :DbContext
    {
        public EntityDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //set Connectionstring
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MovieInfo;User ID=sa;Password=kensindy;TrustServerCertificate=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserID)
                .ValueGeneratedNever(); // Configure UserID as non-identity

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserID) // Create a unique index on UserID
                .IsUnique();

            modelBuilder.Entity<Movie>()
                .Property(m => m.MovieID)
                .ValueGeneratedNever(); // Configure UserID as non-identity

            modelBuilder.Entity<Movie>()
                .HasIndex(m => m.MovieID) // Create a unique index on UserID
                .IsUnique();

            //modelBuilder.Entity<Rating>().HasNoKey(); // Define Rating entity as keyless
            modelBuilder.Entity<Rating>().HasKey(r => new { r.UserID, r.MovieID });
        }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
