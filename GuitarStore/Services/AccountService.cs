using GuitarStore.DTOs;
using GuitarStore.Interfaces;

namespace GuitarStore.Services;

public class AccountService : IAccountService
{
    public Task<LoginDto> LoginAsync(LoginRequestDto request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseErrorDto?> RegisterAsync(RegisterRequestDto request)
    {
        throw new NotImplementedException();
    }
}