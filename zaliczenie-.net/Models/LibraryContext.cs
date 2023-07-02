using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zaliczenie_.net.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Library> Books { get; set; }
        public DbSet<Library> Tittle { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>().HasKey(e => e.idBook);
            //modelBuilder.Entity<Library>().HasKey(e => e.Tittle);
            modelBuilder.Entity<Library>().ToTable("Books", "dbo");
        }
    }
}
