using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class Skill
{
    public int SkillId { get; set; }
    [Required(ErrorMessage = "Yetenek alanını doldurun.")]
    
    public string Title { get; set; } = "";
    [Required(ErrorMessage = "Seviye (%) alanını doldurun.")]
    [Range(0, 100, ErrorMessage = "Seviye 0 ile 100 arasında olmalı.")]
    public int Value { get; set; }

}
