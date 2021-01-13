using System;
using System.Collections.Generic;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.ViewModels
{
    public class CategoryVM
    {
        public IEnumerable<ToDoCategory> Top5;
        public IEnumerable<ToDoCategory> Items;
    }
}
