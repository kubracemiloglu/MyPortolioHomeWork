using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class Feature
{
    public int FeatureId { get; set; }
    [Required(ErrorMessage = "Karşılama başlığı alanını doldurun.")]
    
    public string Title { get; set; } = "";
    [Required(ErrorMessage = "Tanıtım metni alanını doldurun.")]
    
    public string Description { get; set; } = "";

}
