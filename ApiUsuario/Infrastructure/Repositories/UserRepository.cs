using ApiUsuario.Application.DTOs;
using ApiUsuario.Application.Services;
using ApiUsuario.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;

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
    public List<UserDTO> GetId(int userId)
    {
        bool validacao = _context.User.Any(u => u.UsuarioId == userId && u.Profile == "Admin" && u.Status == "Ativado");
        if (validacao)
        {
            var users = _context.User.Where(u => u.Status == "Ativado").Select(u => new UserDTO
            {
                UsuarioId = u.UsuarioId,
                Name = u.Name,
                UserName = u.UserName,
                Cpf = u.Cpf,
                Email = u.Email,
                NumberPhone = u.NumberPhone,
                Address = u.Address,
                NumberHome = u.NumberHome,
                BirthdayData = u.BirthdayData,
                CreatedDate = u.CreatedDate,
                Profile = u.Profile,
                Status = u.Status,
                Password = null
            }).ToList();

            return users;
        }
        else
        {
            return new List<UserDTO>();
        }
    }
    //Retorna o perfil do Usuário
    public string GetProfile(string userName)
    {
        var user = _context.User.First(u => u.UserName == userName && u.Status == "Ativado");

        return user.GetProfile();
    }

    //Verifica Acesso - autentificador
    public User Get(string userName, string password)
    {
        return _context.User.First(u => u.UserName == userName && u.Password == password && u.Status == "Ativado");
    }


    //Retorna os dados do usuário
    public string GetUser(string userName)
    {
        var user = _context.User.FirstOrDefault(u => u.UserName == userName && u.Status == "Ativado");

        if(user == null)
        {
            return "Usuário não existe";
        }
        return user.GetDados();
    }

    //Reset de senha sem acesso ao login
    public string GetResetEmail(string userName, long cpf, string email)
    {

        var user = _context.User.FirstOrDefault(u => u.UserName == userName && u.Cpf == cpf && u.Email == email && u.Status == "Ativado");
        if (user != null)
        {
            user.RecuperarSenha(); // Atualiza a senha do usuário
            _context.SaveChanges(); // Salva as alterações no banco de dados

            return "Email enviado com sucesso"; // Retorna a nova senha
        }
        else
        {
            return null;
        }
    }
    
    //Reset de senha depois do login
    public string PutResetSenha(string userName, string email, string password)
    {

        var user = _context.User.FirstOrDefault(u => u.UserName == userName && u.Email == email && u.Status == "Ativado");
        if (user != null)
        {
            user.ResetPassword(password); // Atualiza a senha do usuário
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return user.Password; // Retorna a nova senha
        }
        else
        {
            return null;
        }
    }
    
    //Desativa usuário
    public bool PutDeleteUser (string userName, string email, string password) 
    {
        var user = _context.User.FirstOrDefault(u => u.UserName == userName && u.Email == email && u.Password == password && u.Status == "Ativado");
        if (user != null) 
        {
             user.DeleteUser();
            _context.SaveChanges();
            return true;
        

        }
        return false;       
    }
}
