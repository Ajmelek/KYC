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
                new Claim("Prenom", client.Prenom ?? string.Empty)
            };

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