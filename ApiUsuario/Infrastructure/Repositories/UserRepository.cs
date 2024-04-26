using ApiUsuario.Application.DTOs;
using ApiUsuario.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuario.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ConnectionContext _context = new ConnectionContext();
    
    //Adiciona Usuario no banco
    public void Add(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
    }

    //Retorna todos os dados para usuário Admin
        public List<User> GetId(int userId)
        {
        var user = _context.User.FirstOrDefault(u => u.UsuarioId == userId && u.Profile == "Admin");
        var userList = user.DadosAdm().ToList();
        if (user != null)
        {
            return userList;
        }
        return new List<User>();
    }

    //Retorna o perfil do Usuário
    public string GetProfile(string userName)
    {
        var user = _context.User.First();

        return user.GetProfile(userName);
    }

    //Verifica Acesso - autentificador
    public User Get(string userName, string password)
    {
        return _context.User.First(u => u.UserName == userName && u.Password == password);
    }


    //Retorna os dados do usuário
    public string GetUser(string userName)
    {
        var user = _context.User.FirstOrDefault(u => u.UserName == userName);

        if(user == null)
        {
            return "Usuário não existe";
        }
        return user.GetDados();
    }
    public string GetResetEmail(string userName, long cpf, string email)
    {
        var user = _context.User.FirstOrDefault();
        var newPassword = user.recuperarSenha(userName, cpf, email);
        return newPassword;
    }

}
