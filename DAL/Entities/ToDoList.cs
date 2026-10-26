using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.DAL.Entities;
public class ToDoList
{
    public int ToDoListId { get; set; }
    [Required(ErrorMessage = "İçerik alanını doldurun.")]
    
    public string Title { get; set; } = "";
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    
    public string ImageUrl { get; set; } = "";
    [Required(ErrorMessage = "Tarih alanını doldurun.")]
    [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Geçerli bir tarih girin.")]
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}
