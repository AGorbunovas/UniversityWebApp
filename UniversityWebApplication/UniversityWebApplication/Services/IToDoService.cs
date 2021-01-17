using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Services
{
    public interface IToDoService
    {
        void AddToDos();

        void EditToDos();

        void DeleteToDos();
    }
}
