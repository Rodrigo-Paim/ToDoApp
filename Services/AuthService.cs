using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public interface IAuthService
    {
        string Authenticate(string username, string password);
        bool Register(User user, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);
            if (user == null || user.PasswordHash != password) return null;

            var keyString = "H9s5Kjh8PQzXnLqR87JhFgT9MlQcR2Dx";
            var key = Encoding.UTF8.GetBytes(keyString);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool Register(User user, string password)
        {
            if (_context.Users.Any(u => u.Username == user.Username)) return false;

            user.PasswordHash = password; // Add proper hashing here
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
