using System;
using System.Linq;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.ToDoCategories.Any())
            {
                return;
            }

            var toDoCategory = new ToDoCategory[]
                {
                    new ToDoCategory
                    {
                        CategoryName = "Work"
                    },
                    new ToDoCategory
                    {
                        CategoryName = "Home"
                    }
                };
            context.ToDoCategories.AddRange(toDoCategory);
            context.SaveChanges();

            var toDoList = new ToDo[]
                {
                    new ToDo
                    {
                        Description = "Peržiūrėti paštą",
                        IsDone = false,
                        ToDoCategory_Id = 1
                    },
                    new ToDo
                    {
                        Description = "Nueiti į parduotuvę",
                        IsDone = false,
                        ToDoCategory_Id = 2
                    },
                    new ToDo
                    {
                        Description = "Susitikimas su užsakovu",
                        IsDone = true,
                        ToDoCategory_Id = 1
                    },
                    new ToDo
                    {
                        Description = "Kelionė į kalnus",
                        IsDone = true,
                        ToDoCategory_Id = 2
                    }
                };
            context.ToDos.AddRange(toDoList);
            context.SaveChanges();
        }
    }
}
