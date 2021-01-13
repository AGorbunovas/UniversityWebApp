namespace UniversityWebApplication.Models
{
    public class ToDoLabel
    {
        public int LabelId { get; set; }
        public Label Label { get; set; }

        public int ToDoId { get; set; }
        public ToDo ToDo { get; set; }
    }
}
