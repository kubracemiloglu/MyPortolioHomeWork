using System.ComponentModel.DataAnnotations;
namespace MyPortolioHomeWork.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Kullanıcı adı gerekli.")]
    public string UserName { get; set; } = "";
    [Required(ErrorMessage = "Şifre gerekli.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";
    public string? ReturnUrl { get; set; }
}

public class SetupModel : LoginModel
{
    [Required(ErrorMessage = "Ad soyad gerekli.")]
    public string DisplayName { get; set; } = "";
    [Required, EmailAddress(ErrorMessage = "Geçerli bir e-posta girin.")]
    public string Email { get; set; } = "";
    [Compare(nameof(Password), ErrorMessage = "Şifreler eşleşmiyor.")]
    public string ConfirmPassword { get; set; } = "";
}

public class ProfileModel
{
    [Required(ErrorMessage = "Ad soyad gerekli.")]
    public string DisplayName { get; set; } = "";
    [Required, EmailAddress(ErrorMessage = "Geçerli bir e-posta girin.")]
    public string Email { get; set; } = "";
}

public class ChangePasswordModel
{
    [Required(ErrorMessage = "Mevcut şifre gerekli.")]
    public string CurrentPassword { get; set; } = "";
    [Required, MinLength(8, ErrorMessage = "Yeni şifre en az 8 karakter olmalı.")]
    public string NewPassword { get; set; } = "";
    [Compare(nameof(NewPassword), ErrorMessage = "Şifreler eşleşmiyor.")]
    public string ConfirmPassword { get; set; } = "";
}
