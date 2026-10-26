using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.Models;

public class ContactMessageModel
{
    [Required(ErrorMessage = "Ad soyad gerekli."), StringLength(100, MinimumLength = 2)]
    public string ContactName { get; set; } = "";
    [Required(ErrorMessage = "E-posta gerekli."), EmailAddress(ErrorMessage = "Geçerli bir e-posta girin."), StringLength(200)]
    public string ContactEmail { get; set; } = "";
    [Required(ErrorMessage = "Konu gerekli."), StringLength(200)]
    public string ContactSubject { get; set; } = "";
    [Required(ErrorMessage = "Mesaj gerekli."), StringLength(5000, MinimumLength = 5)]
    public string ContactMessage { get; set; } = "";
    public string? Company { get; set; }
}
