using ApiUsuario.Domain.Model;

namespace ApiUsuario.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ConnectionContext _context = new ConnectionContext();
    public void Add(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
    }

    public List<User> Get()
    {
        return _context.User.ToList();
    }

    public User Get(string userName, string password)
    {
        return _context.User.FirstOrDefault(u => u.UserName == userName && u.Password == password);
    }
}
