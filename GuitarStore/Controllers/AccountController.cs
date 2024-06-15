using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers;

[Route("api/account")]
[ApiController]
[AllowAnonymous]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        var result = await _accountService.RegisterAsync(dto);
        if (result != null) return Conflict(result.Message);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var result = await _accountService.LoginAsync(dto);

        if (result is ResponseErrorDto error)
            return error.Status == 500 ? StatusCode(500, error.Message) : Unauthorized(error.Message);

        return Ok(result);
    }
}