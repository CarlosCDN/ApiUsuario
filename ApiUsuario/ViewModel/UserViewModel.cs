using System.Xml.Linq;

namespace ApiUsuario.ViewModel
{
    public class UserViewModel
    {

        public int usuarioId { get; private set; }

        public string name { get; set; }

        public int cpf { get; set; }

        public string birthdayData { get; set; }

        public int numberPhone { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string address { get; set; }

        public int numberHome { get; set; }

        public DateTime CreatedDate { get; private set; }
    }
}
