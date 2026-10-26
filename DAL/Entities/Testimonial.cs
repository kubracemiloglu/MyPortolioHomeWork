using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class Testimonial
{
    public int TestimonialId { get; set; }
    [Required(ErrorMessage = "Ad soyad alanını doldurun.")]
    
    public string NameSurname { get; set; } = "";
    [Required(ErrorMessage = "Unvan alanını doldurun.")]
    
    public string Title { get; set; } = "";
    [Required(ErrorMessage = "Yorum alanını doldurun.")]
    
    public string Description { get; set; } = "";
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    
    public string ImageUrl { get; set; } = "";

}
