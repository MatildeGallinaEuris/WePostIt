using System.ComponentModel.DataAnnotations;

namespace WePostIt.API.DTOs
{
    public class CreateAuthorDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; init; } = string.Empty;

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; init; } = string.Empty;

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; init; } = string.Empty;
    }
}
