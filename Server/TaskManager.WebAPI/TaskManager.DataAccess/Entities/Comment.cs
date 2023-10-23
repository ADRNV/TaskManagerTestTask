namespace TaskManager.DataAccess.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }

        public byte CommentType { get; set; }

        public byte[] Content { get; set; }

        public Task Task { get; set; }
    }
}
