using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class Experience
{
    public int ExperienceId { get; set; }
    [Required(ErrorMessage = "Firma / kurum alanını doldurun.")]
    
    public string Head { get; set; } = "";
    [Required(ErrorMessage = "Unvan alanını doldurun.")]
    
    public string Title { get; set; } = "";
    [Required(ErrorMessage = "Tarih aralığı alanını doldurun.")]
    
    public string Date { get; set; } = "";
    [Required(ErrorMessage = "Açıklama alanını doldurun.")]
    
    public string Description { get; set; } = "";

}
