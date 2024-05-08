namespace ApiUsuario.Domain.Model
{
    public interface IAccessHistoryRepository
    {
        bool AddAccess(int userId, string userName);
    }
}
