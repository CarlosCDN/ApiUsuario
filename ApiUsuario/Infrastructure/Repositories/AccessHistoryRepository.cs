using ApiUsuario.Domain.Model;

namespace ApiUsuario.Infrastructure.Repositories;

public class AccessHistoryRepository
{
    private readonly ConnectionContext _context = new ConnectionContext();

    //Adiciona Usuario no banco
    public void Add(AccessHistory accessHistory)
    {
        //var salvarToken = new AuthToken(usuarioId);
        _context.AccessHistories.Add(accessHistory);
        _context.SaveChanges();
    }
}
