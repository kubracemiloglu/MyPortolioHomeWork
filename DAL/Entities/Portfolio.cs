using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class Portfolio
{
    public int PortfolioId { get; set; }
    [Required(ErrorMessage = "Proje adı alanını doldurun.")]
    
    public string Title { get; set; } = "";
    [Required(ErrorMessage = "Kategori alanını doldurun.")]
    
    public string SubTitle { get; set; } = "";
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    
    public string ImageUrl { get; set; } = "";
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    
    public string Url { get; set; } = "";
    [Required(ErrorMessage = "Açıklama alanını doldurun.")]
    
    public string Description { get; set; } = "";

}
