using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class About
{
    public int AboutId { get; set; }
    [Required(ErrorMessage = "Başlık alanını doldurun.")]
    
    public string Title { get; set; } = "";
    [Required(ErrorMessage = "Kısa açıklama alanını doldurun.")]
    
    public string SubDescription { get; set; } = "";
    [Required(ErrorMessage = "Detay alanını doldurun.")]
    
    public string Detail { get; set; } = "";

}
