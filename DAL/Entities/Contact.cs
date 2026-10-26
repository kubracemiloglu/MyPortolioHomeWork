using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class Contact
{
    public int ContactId { get; set; }
    [Required(ErrorMessage = "Başlık alanını doldurun.")]
    
    public string Title { get; set; } = "";
    [Required(ErrorMessage = "Açıklama alanını doldurun.")]
    
    public string Description { get; set; } = "";
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    
    public string Phone1 { get; set; } = "";
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    
    public string Phone2 { get; set; } = "";
    [Required(ErrorMessage = "E-posta alanını doldurun.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta girin.")]
    public string Email1 { get; set; } = "";
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Email2 { get; set; } = "";
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    
    public string Address { get; set; } = "";

}
