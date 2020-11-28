using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityWebApplication.Models
{
    public class ToDo
    {
        [Key]
        public int ToDo_Id { get; set; }

        [Required]
        public string ToDoName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Priority { get; set; }

        public bool IsDone { get; set; }

        public int? ToDoCategory_Id { get; set; }

        [NotMapped]
        public ToDoCategory ToDoCategory { get; set; }
    }
}
