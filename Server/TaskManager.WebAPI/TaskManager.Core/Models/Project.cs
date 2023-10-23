namespace TaskManager.Core.Models
{
    public class Project
    {
        public Guid Id { get; set; }

        public string ProjectName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
