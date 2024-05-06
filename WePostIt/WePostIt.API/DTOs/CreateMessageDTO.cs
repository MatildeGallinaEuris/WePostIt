namespace WePostIt.API.DTOs
{
    public class CreateMessageDTO
    {
        public string Text { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}
