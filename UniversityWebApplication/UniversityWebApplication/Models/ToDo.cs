﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityWebApplication.Enum;

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

        [DefaultValue(3)]
        [Required]
        public int Priority { get; set; }

        public bool IsDone { get; set; }

        public int? ToDoCategory_Id { get; set; }

        [NotMapped]
        public ToDoCategory ToDoCategory { get; set; }

        public ToDoStatus? ToDoStatus { get; set; }
    }
}
