using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class SocialMedia
{
    public int SocialMediaId { get; set; }
    [Required(ErrorMessage = "Platform alanını doldurun.")]
    
    public string Title { get; set; } = "";
    [Required(ErrorMessage = "Profil bağlantısı alanını doldurun.")]
    
    public string Url { get; set; } = "";
    [Required(ErrorMessage = "İkon sınıfı alanını doldurun.")]
    
    public string Icon { get; set; } = "";

}
