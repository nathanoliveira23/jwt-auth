using JWTAuthentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace JWTAuthentication.Services
{
    public class JWTTokenService
    {
        public static string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // Utilizado para criar e validar JWT Tokens (Manipulação de tokens)

            byte[] encryptedKey = Encoding.ASCII.GetBytes(JWTToken.secret_key); // Transformando a secret_key em uma matriz de bytes

            // Definindo as claims
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(encryptedKey), 
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // Cria o objeto JWT

            return tokenHandler.WriteToken(token); // Gera o token final (criptografia do header, claim e signature)
        }
    }
}