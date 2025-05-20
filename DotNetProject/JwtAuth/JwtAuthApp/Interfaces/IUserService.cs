using JwtAuthApp.DTOs;

namespace JwtAuthApp.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
