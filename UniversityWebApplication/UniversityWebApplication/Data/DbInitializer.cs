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

            #region Initialize DB data
            ToDoCategory work = new ToDoCategory
            {
                CategoryName = "Darbas"
            };
            ToDoCategory home = new ToDoCategory
            {
                CategoryName = "Namai"
            };
            context.ToDoCategories.AddRange(work, home);

            Label dontDisturb = new Label
            {
                LabelName = "Netrukdyti"
            };
            Label drive = new Label
            {
                LabelName = "Vairuoju"
            };
            context.Labels.AddRange(dontDisturb, drive);

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
            ToDo driveFast = new ToDo
            {
                ToDoName = "Poilsis",
                Description = "Kartingai",
                IsDone = true,
                ToDoCategory = home
            };
            context.ToDos.AddRange(post, buy, meeting, rest, driveFast);

            ToDoLabel dontDisturbAtRest = new ToDoLabel
            {
                ToDo = rest,
                Label = dontDisturb
            };
            ToDoLabel dontDisturbWhileFastDrive = new ToDoLabel
            {
                ToDo = driveFast,
                Label = dontDisturb
            };
            ToDoLabel driveAtDriveFast = new ToDoLabel
            {
                ToDo = driveFast,
                Label = drive
            };
            context.ToDoLabels.AddRange(dontDisturbAtRest, dontDisturbWhileFastDrive, driveAtDriveFast);

            context.SaveChanges();
            #endregion
        }
    }
}
