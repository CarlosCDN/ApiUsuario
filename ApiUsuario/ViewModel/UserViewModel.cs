using System.Xml.Linq;

namespace ApiUsuario.ViewModel
{
    public class UserViewModel
    {

        public int UsuarioId { get; private set; }

        public string Name { get; set; }

        public long Cpf { get; set; }

        public DateTime BirthdayData { get; set; }

        public long NumberPhone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public int NumberHome { get; set; }

        public DateTime CreatedDate { get; private set; }
    }
}
