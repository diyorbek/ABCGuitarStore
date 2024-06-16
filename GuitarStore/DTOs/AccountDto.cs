using System.ComponentModel.DataAnnotations;
using GuitarStore.Models;

namespace GuitarStore.DTOs;

public abstract class AccountDto
{
    public AccountDto()
    {
    }

    public AccountDto(Account account)
    {
        Email = account.Email;
        Name = account.Name;
        Password = account.Password;
        Id = account.Id;
    }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required] [Length(1, 255)] public string Name { get; set; }
    [Required] [Length(1, 255)] public string Password { get; set; }
    public Guid Id { get; set; }
}