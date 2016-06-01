using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialMedia.UI.Web.MVC.Models
{
    public class ChangePasswordVM
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola boş geçilemez")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-zA-Z])\w{8,}$", ErrorMessage = "Şifreniz en az 8 karakter içermeli ve kompleks olmalıdır")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage="Parolalar uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        //image dosyası
        public string RobotTextUrl { get; set; }
        public string RobotText { get; set; }

    }
}