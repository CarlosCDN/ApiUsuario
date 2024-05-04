namespace ApiUsuario.Domain.Model
{
    public interface IAuthTokenRepository
    {
        void add(AuthToken authToken);
    }
}
