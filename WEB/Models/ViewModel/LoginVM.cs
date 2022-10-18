using System.ComponentModel.DataAnnotations;

namespace WEB.Models.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username Girilmedi!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Girilmedi!")]
        public string Password { get; set; }
    }
}
