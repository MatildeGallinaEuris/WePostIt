using System.ComponentModel.DataAnnotations;

namespace WePostIt.API.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IdDeleted { get; set; }

        public Message(
            int id = default,
            [Required(ErrorMessage = "Text is mandatory")]
            [MinLength(5, ErrorMessage = "Text must be at least 5 chars")]
            string text = "",
            int authorId = default,
            DateTime creationTime = default,
            DateTime updateTime = default)
        {

        }
    }
}
