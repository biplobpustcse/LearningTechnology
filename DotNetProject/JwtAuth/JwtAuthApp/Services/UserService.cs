using System.Security.Cryptography;
using System.Text;
using JwtAuthApp.DTOs;
using JwtAuthApp.Helpers;
using JwtAuthApp.Interfaces;
using JwtAuthApp.Models;

namespace JwtAuthApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IConfiguration _config;

    public UserService(IUserRepository repo, IConfiguration config)
    {
        _repo = repo;
        _config = config;
    }

    public async Task<string> RegisterAsync(RegisterDto dto)
    {
        if (await _repo.GetByEmailAsync(dto.Email) != null)
            return "User already exists.";

        CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = hash,
            PasswordSalt = salt,
        };

        await _repo.AddUserAsync(user);
        return "User registered successfully.";
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _repo.GetByEmailAsync(dto.Email);
        if (user == null || !VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            return "Invalid credentials.";

        return JwtHelper.GenerateToken(user.Email, _config["Jwt:Key"]);
    }

    private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new HMACSHA256();
        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
    {
        using var hmac = new HMACSHA256(salt);
        var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return hash.SequenceEqual(computed);
    }
}
