using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityWebApplication.Models;

public class AppDbContext : DbContext
{

    public DbSet<ToDoCategory> ToDoCategories { get; set; }

    public DbSet<ToDo> ToDos { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ToDo>().ToTable("ToDo");
        modelBuilder.Entity<ToDoCategory>().ToTable("ToDoCategory");

        modelBuilder.Entity<ToDo>()
            .HasOne(c => c.ToDoCategory)
            .WithMany(t => t.ToDos)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
