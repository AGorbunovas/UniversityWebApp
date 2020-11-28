using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityWebApplication.Models
{
    public class ToDoCategory
    {
       [Key]
        public int Category_Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public List<ToDo> ToDos { get; set; } = new List<ToDo>();
    }
}
