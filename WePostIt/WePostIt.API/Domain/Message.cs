namespace WePostIt.API.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IdDeleted { get; set; }
    }
}
