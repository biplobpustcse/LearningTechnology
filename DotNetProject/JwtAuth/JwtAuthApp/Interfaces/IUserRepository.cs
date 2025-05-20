using JwtAuthApp.Models;

namespace JwtAuthApp.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
