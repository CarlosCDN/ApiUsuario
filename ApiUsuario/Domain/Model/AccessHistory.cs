namespace ApiUsuario.Domain.Model
{
    public class AccessHistory
    {
        public AccessHistory(int id, int userId, DateTime accessTime, bool sucess)
        {
            Id = id;
            UserId = userId;
            AccessTime = accessTime;
            Sucess = sucess;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime AccessTime{ get; set; }

        public bool Sucess {  get; set; }
    }
}
