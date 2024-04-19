using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiUsuario.Domain.Model;

[Table("usuario")]
public class User
{

    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
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
        CreatedDate = DateTime.Now;


    }

    private int GenerateRandomUserId()
    {
        // Gera um número aleatório de 6 dígitos
        Random random = new Random();
        return random.Next(100000, 999999);
    }

    public bool ValidaCpf(long cpf)
    {
        string cpfString = cpf.ToString().PadLeft(11, '0');

        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf;
        string digito;
        int soma = 0;
        int resto;

        if (cpfString.Length != 11)
            return false;

        tempCpf = cpfString.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpfString.EndsWith(digito);
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


}
