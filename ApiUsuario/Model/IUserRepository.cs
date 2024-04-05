namespace ApiUsuario.Model
{
    public interface IUserRepository
    {
        void Add(User user);

        List<User> Get();  
    }
}
