using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiUsuario.Domain.Model;

[Table("auth_tokens")]
public class AuthToken
{
    public AuthToken(int userId, string token)
    {
        UserId = userId;
        Token = token;
        ExpirationDate = DateTime.Now.AddHours(1);
    }

    public AuthToken() { }
    [Key]
    [Column("id")]
    public int Id { get; private set; }
    [Column("user_id")]
    public int UserId { get; private set; }
    [Column("token")]
    public string Token { get; private set; }
    [Column("expiration_date")]
    public DateTime ExpirationDate { get; private set; }
}
