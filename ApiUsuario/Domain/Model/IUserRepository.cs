namespace ApiUsuario.Domain.Model;

public interface IUserRepository
{
    void Add(User user);

    List<User> Get();

    public User Get(string username, string password);

}
