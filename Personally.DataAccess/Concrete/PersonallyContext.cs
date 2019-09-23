using Microsoft.EntityFrameworkCore;
using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.DataAccess.Concrete
{
    public class PersonallyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PersonallyDb;integrated security=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteCategory>().HasKey(x => new { x.CategoryId, x.NoteId });
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
