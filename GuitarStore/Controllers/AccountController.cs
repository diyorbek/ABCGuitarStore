using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers;

[Route("api/account")]
[ApiController]
[AllowAnonymous]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CustomerRegisterRequestDto dto)
    {
        if (!TryValidateModel(dto)) return BadRequest(ModelState);

        var result = await accountService.RegisterAsync(dto);
        if (result != null) return Conflict(result.Message);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var result = await accountService.LoginAsync(dto);

        if (result is ResponseErrorDto error)
            return error.Status == 500 ? StatusCode(500, error.Message) : Unauthorized(error.Message);

        return Ok(result);
    }
}