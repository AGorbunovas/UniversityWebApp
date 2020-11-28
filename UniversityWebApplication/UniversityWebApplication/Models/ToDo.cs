using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityWebApplication.Models
{
    public class ToDo
    {
        [Key]
        public int ToDo_Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsDone { get; set; }


        public int? ToDoCategory_Id { get; set; }

        public ToDoCategory ToDoCategory { get; set; }
    }
}
