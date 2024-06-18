using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GuitarStore.Contexts;
using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using GuitarStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GuitarStore.Services;

public class AccountService(IConfiguration configuration, AppDbContext context) : IAccountService
{
    public async Task<LoginDto> LoginAsync(LoginRequestDto request)
    {
        var account = await context.Accounts
            .FirstOrDefaultAsync(a => a.Email == request.Email);

        if (account == null || !BCrypt.Net.BCrypt.Verify(request.Password, account.Password))
            return new ResponseErrorDto { Message = "Incorrect login or password." };

        var token = GenerateJwtToken(account);

        return new LoginResponse { Token = token };
    }

    public async Task<ResponseErrorDto?> RegisterAsync(CustomerRegisterRequestDto request)
    {
        if (await context.Accounts.AnyAsync(a => a.Email == request.Email))
            return new ResponseErrorDto { Message = "Email already in use." };

        var account = new RegularCustomer
        {
            Name = request.Name,
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Birthdate = request.Birthdate
        };

        context.Accounts.Add(account);
        await context.SaveChangesAsync();

        return null;
    }

    private string GenerateJwtToken(Account account)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, account.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, account.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:DurationInMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}