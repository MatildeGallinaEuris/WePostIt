namespace WePostIt.API.Domain
{
    public class Message : EntityBase, ISoftDeleteEntity
    {
        public string Text { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public bool IdDeleted { get; set; }
    }
}
