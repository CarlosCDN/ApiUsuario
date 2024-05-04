namespace ApiUsuario.Domain.Model
{
    public interface IAuthTokenRepository
    {
        public string AddToken(int usuarioId, string token);
    }
}
