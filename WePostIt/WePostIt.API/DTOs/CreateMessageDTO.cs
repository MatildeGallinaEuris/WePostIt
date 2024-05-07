using System.ComponentModel.DataAnnotations;

namespace WePostIt.API.DTOs
{
    public class CreateMessageDTO
    {
        [Required, MinLength(5)]
        public string Text { get; set; } = string.Empty;
        [Required]
        public int AuthorId { get; set; }
    }
}
