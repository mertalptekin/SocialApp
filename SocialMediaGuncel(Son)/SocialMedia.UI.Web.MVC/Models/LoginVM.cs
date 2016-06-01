using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialMedia.UI.Web.MVC.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage="E-Posta giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage="Parola Giriniz")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }


    }
}