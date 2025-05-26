using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using STB_everywhere.Models;

namespace STB_everywhere.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        public bool VerifyPasswordHash(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword))
                return false;
            
            string hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }

        public string CreateToken(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null.");
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, client.Login),
                new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
                new Claim("Nom", client.Nom ?? string.Empty),
                new Claim("Prenom", client.Prenom ?? string.Empty),
                new Claim(ClaimTypes.Role, "Client")
            };

            return GenerateToken(claims);
        }

        public string CreateToken(Admin admin)
        {
            if (admin == null)
            {
                throw new ArgumentNullException(nameof(admin), "Admin cannot be null.");
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, admin.Login),
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

            return GenerateToken(claims);
        }

        public string CreateToken(SuperAdmin superAdmin)
        {
            if (superAdmin == null)
            {
                throw new ArgumentNullException(nameof(superAdmin), "SuperAdmin cannot be null.");
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, superAdmin.Login),
                new Claim(ClaimTypes.NameIdentifier, superAdmin.Id.ToString()),
                new Claim(ClaimTypes.Role, "SuperAdmin")
            };

            return GenerateToken(claims);
        }

        private string GenerateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("Jwt:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddHours(double.Parse(_config.GetSection("Jwt:ExpirationHours").Value)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}