using System.ComponentModel.DataAnnotations.Schema;

namespace ApiUsuario.Application.DTOs;

public class UserDTO
{
    public UserDTO(string userName, string name, long cpf, DateTime birthdayData, long numberPhone, string email, string password, string address, int numberHome)
    {
        UserName = userName;
        Name = name;
        Cpf = cpf;
        BirthdayData = birthdayData;
        NumberPhone = numberPhone;
        Email = email;
        Password = password;
        Address = address;
        NumberHome = numberHome;
    }
    public UserDTO( string userName, long cpf,  string email)
    {
        UserName = userName;
        Cpf = cpf;
        Email = email;
    }
    public UserDTO(string userName, string password) 
    {
        this.UserName = userName;  
        this.Password = password;
    }

    public UserDTO(string userName)
    {
        this.UserName = userName;
    }

    public UserDTO(int usuarioId)
    {
        UsuarioId = usuarioId;
    }
    public UserDTO(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        Password = password;    
    }
    public UserDTO() { }

    public int UsuarioId {  get; set; }

    public string UserName { get; set; }
    public string Name { get; set; }

    public long Cpf { get; set; }

    public DateTime BirthdayData { get; set; }

    public long NumberPhone { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Address { get;  set; }

    public int NumberHome { get;  set; }

    public DateTime CreatedDate {  get;  set; }

    public string Profile { get; set; }

    public string Status { get; set; }

}
