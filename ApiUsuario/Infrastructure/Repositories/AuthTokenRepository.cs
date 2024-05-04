using ApiUsuario.Domain.Model;

namespace ApiUsuario.Infrastructure.Repositories;

public class AuthTokenRepository : IAuthTokenRepository
{
    private readonly ConnectionContext _context = new ConnectionContext();

    //Adiciona Usuario no banco
    public string AddToken(int usuarioId,  string token)
    {
        var salvarToken = new AuthToken(usuarioId, token);
        _context.AuthTokens.Add(salvarToken);
        _context.SaveChanges();
        return "Sucesso";
    }
}
