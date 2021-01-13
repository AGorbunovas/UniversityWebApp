using System.ComponentModel.DataAnnotations;

namespace UniversityWebApplication.Models
{
    public class Label
    {
        [Key]
        public int LabelId { get; set; }

        [Required]
        public string LabelName { get; set; }
    }
}
