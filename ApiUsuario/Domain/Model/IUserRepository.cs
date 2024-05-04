using ApiUsuario.Application.DTOs;

namespace ApiUsuario.Domain.Model;

public interface IUserRepository
{
    void Add(User user);

    List<UserDTO> GetId(int Id);

    public string GetUser(string username);

    public string GetProfile(string username);

    public int Get(string username, string password);

    public string GetResetEmail(string useName, long cpf, string email);

    public string PutResetSenha(string username, string email, string password);

    public bool PutDeleteUser(string username, string email, string password);
}
