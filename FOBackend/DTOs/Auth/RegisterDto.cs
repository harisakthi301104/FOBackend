using System.ComponentModel.DataAnnotations;

namespace FOBackend.DTOs.Auth
{
    // DTO for user registration request
    public class RegisterDto
    {
        // User's full name
        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        // User's email address
        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        // User's password (plain text — will be hashed)
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
