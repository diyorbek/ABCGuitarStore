using GuitarStore.DTOs;

namespace GuitarStore.Interfaces;

public interface IAccountService
{
    Task<LoginDto> LoginAsync(LoginRequestDto request);
    Task<ResponseErrorDto?> RegisterAsync(RegisterRequestDto request);
}