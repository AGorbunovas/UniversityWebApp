using Microsoft.EntityFrameworkCore;
using UniversityWebApplication.Models;

public class AppDbContext : DbContext
{

    public DbSet<ToDoCategory> ToDoCategories { get; set; }
    public DbSet<ToDo> ToDos { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<ToDoLabel> ToDoLabels { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ToDoCategory>().ToTable("ToDoCategory");
        modelBuilder.Entity<ToDo>().ToTable("ToDo");
        modelBuilder.Entity<Label>().ToTable("Label");
        modelBuilder.Entity<ToDoLabel>().ToTable("ToDoLabel");

        modelBuilder.Entity<ToDo>()
            .HasOne(c => c.ToDoCategory)
            .WithMany(t => t.ToDos)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ToDo>()
            .Property(t => t.Priority).HasDefaultValue(3);

        modelBuilder.Entity<ToDoLabel>()
            .HasKey(toDoLabel => new { toDoLabel.LabelId, toDoLabel.ToDoId});
    }
}
