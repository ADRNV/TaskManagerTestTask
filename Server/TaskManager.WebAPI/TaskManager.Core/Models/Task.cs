namespace TaskManager.Core.Models
{
    public class Task
    {
        public Guid Id { get; set; }

        public string TaskName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CancelDate { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public List<Comment> Comments { get; set; } = new();

        public Project Project { get; set; }
    }
}
