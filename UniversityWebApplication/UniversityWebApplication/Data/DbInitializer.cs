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
            #region First initialize method
            /*
            ToDoCategory work = new ToDoCategory { CategoryName = "Work" };
            ToDoCategory home = new ToDoCategory { CategoryName = "Home" };
            context.ToDoCategories.AddRange(work, home);

            ToDo pastas = new ToDo { ToDoName = "Paštas", Description = "Peržiūrėti paštą", IsDone = false, Priority = 4, ToDoCategory = work };
            ToDo apsipirkimai = new ToDo { ToDoName = "Apsipirkimai", Description = "Nueiti į parduotuvę", IsDone = false, Priority = 3, ToDoCategory = home };
            ToDo susitikimai = new ToDo { ToDoName = "Susitikimai", Description = "Susitikimas su užsakovu", IsDone = false, Priority = 4, ToDoCategory = work };
            ToDo poilsis = new ToDo { ToDoName = "Poilsis", Description = "Kelionė į kalnus", IsDone = true, Priority = 2, ToDoCategory = home };
            context.ToDos.AddRange(pastas, apsipirkimai, susitikimai, poilsis);

            context.SaveChanges();
            */
            #endregion

            #region Second initialize method
            ToDoCategory work = new ToDoCategory
            {
                CategoryName = "Work"
            };
            ToDoCategory home = new ToDoCategory
            {
                CategoryName = "Home"
            };
            context.ToDoCategories.AddRange(work, home);

            ToDo post = new ToDo
            {
                ToDoName = "Paštas",
                Description = "Peržiūrėti paštą",
                Priority = 4,
                IsDone = false,
                ToDoCategory = work
            };
            ToDo buy = new ToDo
            {
                ToDoName = "Apsipirkimai",
                Description = "Nueiti į parduotuvę",
                Priority = 3,
                IsDone = false,
                ToDoCategory = home
            };
            ToDo meeting = new ToDo
            {
                ToDoName = "Susitikimai",
                Description = "Susitikimas su užsakovu",
                Priority = 4,
                IsDone = true,
                ToDoCategory = work
            };
            ToDo rest = new ToDo
            {
                ToDoName = "Poilsis",
                Description = "Kelionė į kalnus",
                Priority = 2,
                IsDone = true,
                ToDoCategory = home
            };
            ToDo drive = new ToDo
            {
                ToDoName = "Poilsis",
                Description = "Kartingai",
                IsDone = true,
                ToDoCategory = home
            };
            context.ToDos.AddRange(post, buy, meeting, rest, drive);

            context.SaveChanges();
            #endregion
        }
    }
}
