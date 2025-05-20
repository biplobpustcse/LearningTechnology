using JwtAuthApp.Data;
using JwtAuthApp.Interfaces;
using JwtAuthApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<User> GetByEmailAsync(string email) =>
            _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
