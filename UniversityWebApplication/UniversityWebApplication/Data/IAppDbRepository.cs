using System.Linq;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.Data
{
    public interface IAppDbRepository
    {
        public IQueryable<ToDo> ToDos { get; }

        public IQueryable<ToDoCategory> ToDoCategories { get; }

        void Add<EntityType>(EntityType entity);

        void SaveChanges();
    }
}
