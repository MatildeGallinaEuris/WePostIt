using System.ComponentModel.DataAnnotations;

namespace WePostIt.API.DTOs
{
    public class UpdateAuthorDTO
    {
        [Required]
        public string Name { get; init; } = string.Empty;

        [Required]
        public string Surname { get; init; } = string.Empty;
    }
}
