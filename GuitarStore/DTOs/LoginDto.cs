namespace GuitarStore.DTOs;

public abstract class LoginDto
{
}

public class ResponseErrorDto : LoginDto
{
    public string Message { get; set; }
    public int Status { get; set; }
}

public class RegisterRequestDto : LoginDto
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}

public class LoginResponse : LoginDto
{
    public string Token { get; set; }
}

public class LoginRequestDto : LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}