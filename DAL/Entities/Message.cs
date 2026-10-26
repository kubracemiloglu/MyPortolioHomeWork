using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class Message
{
    public int MessageId { get; set; }
    [Required] public string NameSurname { get; set; } = "";
    [Required] public string Subject { get; set; } = "";
    [Required, EmailAddress] public string Email { get; set; } = "";
    [Required] public string MessageDetail { get; set; } = "";
    public DateTime SendDate { get; set; }
    public bool IsRead { get; set; }
}
