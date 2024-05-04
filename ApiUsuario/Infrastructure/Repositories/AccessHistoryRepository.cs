using ApiUsuario.Domain.Model;

namespace ApiUsuario.Infrastructure.Repositories
{
    public class AccessHistoryRepository : IAccessHistoryRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        //Adiciona Usuario no banco
        public void Add(AccessHistory accessHistory)
        {
            _context.LogAcess.Add(accessHistory);
            _context.SaveChanges();
        }
    }
}
