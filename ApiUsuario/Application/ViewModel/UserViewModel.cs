using System.Xml.Linq;
namespace ApiUsuario.Application.ViewModel;

public class UserViewModel
{

    public string UserName { get; set; }

    public string Name { get; set; }

    public long Cpf { get; set; }

    public DateTime BirthdayData { get; set; }

    public long NumberPhone { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Address { get; set; }

    public int NumberHome { get; set; }


}
