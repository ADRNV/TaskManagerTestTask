namespace TaskManager.Core.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public byte CommentType { get; set; }

        public byte[] Content { get; set; }
    }
}
