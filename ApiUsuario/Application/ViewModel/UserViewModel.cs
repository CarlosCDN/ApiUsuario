using System.Net.Mail;
using System.Xml.Linq;
namespace ApiUsuario.Application.ViewModel;

public class UserViewModel
{
    public UserViewModel(string userName, string name, long cpf, DateTime birthdayData, long numberPhone, string email, string password, string address, int numberHome)
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

    public UserViewModel(string userName, string name, long cpf, DateTime birthdayData, long numberPhone, string email, string address, int numberHome)
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
    public UserViewModel() { }

    public string UserName { get; set; }

    public string Name { get; set; }

    public long Cpf { get; set; }

    public DateTime BirthdayData { get; set; }

    public long NumberPhone { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Address { get; set; }

    public int NumberHome { get; set; }

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

    public bool IsValidEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email || email.EndsWith(".br", StringComparison.OrdinalIgnoreCase); ;
        }
        catch 
        { 
        return false;
        } 
    }

}
