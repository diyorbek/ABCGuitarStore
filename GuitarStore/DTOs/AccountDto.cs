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

    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }
}