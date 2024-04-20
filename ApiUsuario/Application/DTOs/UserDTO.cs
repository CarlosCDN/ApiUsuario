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

    public int UsuarioId { get; set; }

    public string UserName { get; set; }
    public string Name { get; set; }

    public long Cpf { get; set; }

    public DateTime BirthdayData { get; set; }

    public long NumberPhone { get; set; }

    public string Email { get; set; }

    public string Password { get;  set; }

    public string Address { get;  set; }

    public int NumberHome { get;  set; }

    public DateTime CreatedDate { get;  set; }

}
