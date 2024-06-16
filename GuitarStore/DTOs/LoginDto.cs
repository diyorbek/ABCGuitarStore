using System.ComponentModel.DataAnnotations;
using GuitarStore.Helpers;

namespace GuitarStore.DTOs;

public abstract class LoginDto
{
}

public class ResponseErrorDto : LoginDto
{
    public string Message { get; set; }
    public int Status { get; set; }
}

public class CustomerRegisterRequestDto : LoginDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required] [Length(1, 255)] public string Name { get; set; }
    [Required] [Length(1, 255)] public string Password { get; set; }
    [Required] [MinimumAge(18)] public DateTime Birthdate { get; set; }
}

public class LoginResponse : LoginDto
{
    public string Token { get; set; }
}

public class LoginRequestDto : LoginDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required] [Length(1, 255)] public string Password { get; set; }
}