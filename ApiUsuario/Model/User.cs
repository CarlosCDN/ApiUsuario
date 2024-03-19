namespace ApiUsuario.Model
{
    public class User
    {
        public int id { get; private set; }

        public string name { get; set; }

        public int cpf { get; set; }

        public DateTime birthdayData { get; set; }

        public int numberPhone { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string address { get; set; }

        public string numberHome { get; set; }

        public DateTime CreatedDate { get; set; }


    }
}
