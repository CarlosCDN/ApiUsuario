using ApiUsuario.Application.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiUsuario.Domain.Model;

[Table("usuario")]
public class User
{
    public User(string name, string userName, long cpf, DateTime birthdayData, long numberPhone, string email, string password, string address, int numberHome, int usuarioId = 0)
    {
        UsuarioId = usuarioId == 0 ? GenerateRandomUserId() : usuarioId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        UserName = userName;
        Cpf = cpf;
        BirthdayData = birthdayData;
        NumberPhone = numberPhone;
        Email = email;
        Password = HashPassword(password);
        Address = address;
        NumberHome = numberHome;
        CreatedDate = DateTime.Now;
        Profile = "Cliente";
        Status = "Ativado";
    }

    private int GenerateRandomUserId()
    {
        // Gera um número aleatório de 6 dígitos
        Random random = new Random();
        return random.Next(100000, 999999);
    }

    //Gera senha aleatoria para alteração
    public static string GenerateRandomPassword()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, 10) // Defina o comprimento da senha aqui (por exemplo, 10 caracteres)
         .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public User() { }

    //Retorna Profile
    public string GetProfile()
    {
        return Profile;
    }

    // Retorna dados do Usuário
    public string GetDados()
    {
        return $"Nome: {Name}\nUserName: {UserName}\nCPF: {Cpf}\nE-mail: {Email}\nTelefone: {NumberPhone}\nEndereço: {Address}, {NumberHome}\nData de Nascimento: {BirthdayData}\n";
    }

    //Desativa User
    public bool DeleteUser()
    {
        var status = "Inativo";
        Status = status;
        return true;
    }

    //Troca de senha
    public bool ResetPassword(string newPassword)
    {
        Password = HashPassword(newPassword);
        return true;
    }

    public bool RecuperarSenha()
    {

        var senderEmail = new MailService("", ""); // No primeiro "" é colocado o e-mail, no caso está configurado para outlook. No segundo é passado a senha do email
        var newPassword = GenerateRandomPassword();
        var validador = senderEmail.SendeMail(Email, "Recuperacao de senha", $"Olá! Sua nova senha é: {newPassword}"); // Envia nova senha

        if (validador)
        {
            Password = HashPassword(newPassword);
            return validador;
        }
        else
            return false;
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
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
    public string Password { get; private set; }

    [Column("address")]
    public string Address { get; private set; }

    [Column("numberhome")]
    public int NumberHome { get; private set; }

    [Column("createddate")]
    public DateTime CreatedDate { get; private set; }

    [Column("profile")]
    public string Profile { get; private set; }
    [Column("status")]
    public string Status { get; private set; }
}
