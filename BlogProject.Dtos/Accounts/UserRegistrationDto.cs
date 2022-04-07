using System.ComponentModel.DataAnnotations;


namespace BlogProject.Dtos.Accounts;

public class UserRegistrationDto
{
    [Required]
    public string? Username { get; set; }

    [EmailAddress]
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}
