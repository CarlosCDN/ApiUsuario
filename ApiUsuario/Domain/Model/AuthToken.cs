namespace ApiUsuario.Domain.Model
{
    public class AuthToken
    {
        public AuthToken(int id, int userId, string token, DateTime expirationDate)
        {
            Id = id;
            UserId = userId;
            Token = token;
            ExpirationDate = expirationDate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
