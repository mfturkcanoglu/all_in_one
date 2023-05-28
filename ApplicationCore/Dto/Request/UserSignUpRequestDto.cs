using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Dto.Request;

public class UserSignUpRequestDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
    public string FullName { get; set; }
    public string CountryId { get; set; }
    public string Photo { get; set; } = string.Empty;
}