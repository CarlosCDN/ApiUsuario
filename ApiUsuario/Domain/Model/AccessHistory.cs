using System.ComponentModel.DataAnnotations.Schema;

namespace ApiUsuario.Domain.Model;

[Table("access_history")]
public class AccessHistory
{
    public AccessHistory(int userId, string userName, bool sucess)
    {
        UserId = userId;
        UserName = userName;
        AccessTime = DateTime.Now;
        Sucess = sucess;
    }


    public AccessHistory() { }

    [Column("id")]
    public int Id { get; set; }

    [Column("user_name")]
    public string UserName { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("access_time")]
    public DateTime AccessTime { get; set; }

    [Column("sucess")]
    public bool Sucess { get; set; }
}
     