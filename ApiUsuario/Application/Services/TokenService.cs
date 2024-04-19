using ApiUsuario.Domain.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiUsuario.Application.Services;

public class TokenService
{
    public static object GenerateToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(Key.Secret);

        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("userId", user.UsuarioId.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var TokenHandler = new JwtSecurityTokenHandler();
        var token = TokenHandler.CreateToken(tokenConfig);
        var tokenString = TokenHandler.WriteToken(token);

        return new
        {
            token = tokenString
        };
    }
}
