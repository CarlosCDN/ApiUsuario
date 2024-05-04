using ApiUsuario.Domain.Model;

namespace ApiUsuario.Infrastructure.Repositories
{
    public class AuthTokenRepository : IAuthTokenRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        //Adiciona Usuario no banco
        public void Add(AuthToken authToken)
        {
            _context.Token.Add(authToken);
            _context.SaveChanges();
        }
    }
}
