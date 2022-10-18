using System.ComponentModel.DataAnnotations;

namespace WEB.Models.ViewModel
{
    public class RegisterVM
    {
        [Required (ErrorMessage ="Username Girilmedi!")]
        public string Username { get; set; }
        [Required (ErrorMessage ="Email Girilmedi!")]
        public string Email { get; set; }
        [Required (ErrorMessage ="Şifre Girilmedi!")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Şifre (Tekrar) Girilmedi!")]
        [Compare("Password" , ErrorMessage ="Şifreler Uyuşmuyor!" )]
        public string ConfirmPassword { get; set; }
    }
}
