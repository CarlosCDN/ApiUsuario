using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiUsuario.Domain.Model;

[Table("usuario")]
public class User
{
    public User(string name, string userName, long cpf, DateTime birthdayData, long numberPhone, string email, string password, string address, int numberHome, int usuarioId = 0)

    {
        //Colocar while para gerar um código que não exista no BD

        UsuarioId = usuarioId == 0 ? GenerateRandomUserId() : usuarioId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        UserName = userName;
        Cpf = cpf;
        BirthdayData = birthdayData;
        NumberPhone = numberPhone;
        Email = email;
        Password = password;
        Address = address;
        NumberHome = numberHome;
        CreatedDate = DateTime.UtcNow;
        Profile = "Cliente";
        Status = "Ativado";
    }


    public User(string userName, string name, long cpf, DateTime birthdayData, long numberPhone, string email, string address, int numberHome)
    {
        UserName = userName;
        Name = name;
        Cpf = cpf;
        BirthdayData = birthdayData;
        NumberPhone = numberPhone;
        Email = email;
        Address = address;
        NumberHome = numberHome;
    }



    public Boolean AddUser(string name, string userName, long cpf, DateTime birthdayData, long numberPhone, string email, string password, string address, int numberHome, int usuarioId = 0)
    {
        if (usuarioId != UsuarioId)
        {
            UsuarioId = usuarioId == 0 ? GenerateRandomUserId() : usuarioId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            UserName = userName;
            Cpf = cpf;
            BirthdayData = birthdayData;
            NumberPhone = numberPhone;
            Email = email;
            Password = password;
            Address = address;
            NumberHome = numberHome;
            CreatedDate = DateTime.UtcNow;
            Profile = "Cliente";
            Status = "Ativado";
            return true;
        }
        else
            return false;

    }
    private int GenerateRandomUserId()
    {
        // Gera um número aleatório de 6 dígitos
        Random random = new Random();
        return random.Next(100000, 999999);
    }

    private string GenerateRandomPassword()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, 10) // Defina o comprimento da senha aqui (por exemplo, 10 caracteres)
         .Select(s => s[random.Next(s.Length)]).ToArray());
    }


    public User() {    }

    public List<User> DadosAdm()
    {
        var status = "Ativado";
        if (Status == status)
        {
            var user = new User
            {
                UsuarioId = UsuarioId,
                Name = Name,
                UserName = UserName,
                Cpf = Cpf,
                Email = Email,
                NumberPhone = NumberPhone,
                Address = Address,
                NumberHome = NumberHome,
                BirthdayData = BirthdayData,
                CreatedDate = CreatedDate,
                Profile = Profile,
                Status = Status
            };
            Password = null;

            return new List<User>{ user };
        }
        else
        {
            return new List<User>();
        }
    }

    //Retorna Profile
    public string GetProfile(string userName)
    {
        //Colocar para ignorar minuscula e maiuscula
        if (userName == UserName)
            return Profile;
        else
            return "Usuario não existe";
    }

    // Retorna dados do Usuário
    public string GetDados()
    {
        var status = "Ativado";
        if (this.Status == status)
        return $"Nome: {Name}\nUserName: {UserName}\nCPF: {Cpf}\nE-mail: {Email}\nTelefone: {NumberPhone}\nEndereço: {Address}, {NumberHome}\nData de Nascimento: {BirthdayData}\n";
        else
        {
            return "Usuário não encontrado";
        }
    }

    //Desativa User
    public bool DeleteUser(string userName, string email , string password)
    {
        var status = "Inativo";
        if (userName == UserName && email == Email && password == Password)
        {
            Status = status;

            return true;
        }
        return false;
    }

    //Troca de senha
    public bool resetPassword(string newPassword)
    {
        Password = newPassword;
        return true;
    }

    public string recuperarSenha(string userName, long cpf, string email)
    {
        if (Email == email && Cpf == cpf && UserName == userName)
        {
            var newPassword = GenerateRandomPassword();
            Password = newPassword;
            return newPassword;
        }
        else
            return "Dados não compativeis";
    }
   


    [Column("usuario_id")]
    [Key]
    public int UsuarioId { get; private set; }
    [Column("user_name")]
    public string UserName { get; private set; }

    [Column("name")]
    public string Name { get; private set; }

    [Column("cpf")]
    public long Cpf { get; private set; }

    [Column("birthday_data")]
    public DateTime BirthdayData { get; private set; }

    [Column("number_phone")]
    public long NumberPhone { get; private set; }

    [Column("email")]
    public string Email { get; private set; }

    [Column("password")]
    public string Password {  get; private set; }

    [Column("address")]
    public string Address { get; private set; }

    [Column("numberhome")]
    public int NumberHome { get; private set; }

    [Column("createddate")]
    public DateTime CreatedDate { get; private set; }

    [Column("profile")]
    public string Profile { get; private set; }
    [Column("status")]
    public string Status {  get; private set; }
}
