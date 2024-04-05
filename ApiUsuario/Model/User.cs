using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiUsuario.Model
{
    [Table("user")]
    public class User
    {
        public User(string name, int cpf, string birthdayData, int numberPhone, string email, string password, string address, int numberHome, int usuarioId = 0)

        {
            this.usuarioId = usuarioId == 0 ? GenerateRandomUserId() : usuarioId;
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.cpf = cpf;
            this.birthdayData = birthdayData;
            this.numberPhone = numberPhone;
            this.email = email;
            this.password = password;
            this.address = address;
            this.numberHome = numberHome;
            this.CreatedDate = DateTime.Now;
        }

        private int GenerateRandomUserId()
        {
            // Gera um número aleatório de 6 dígitos
            Random random = new Random();
            return random.Next(100000, 999999);
        }



        [Column("usuario_id")]
        [Key]
        public int usuarioId { get; private set; }

        [Column("name")]
        public string name { get; private set; }

        [Column("cpf")]
        public int cpf { get; private set; }

        [Column("birthday_data")]
        public string birthdayData { get; private set; }

        [Column("number_phone")]
        public int numberPhone { get; private set; }

        [Column("email")]
        public string email { get; private set; }

        [Column("password")]
        public string password { get; private set; }

        [Column("adress")]
        public string address { get; private set; }

        [Column ("numberhome")]
        public int numberHome { get; private set; }

        [Column("createddate")]
        public DateTime CreatedDate { get; private set; }

  
    }
}
