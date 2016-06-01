using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DTO.Layer.Model
{
    public class AppUserDTO:DTOBase
    {
        [Required(ErrorMessage="Lütfen Kullanıcı Adınızı doldurunuz")]
        public string UserName { get; set; }


        [Required(ErrorMessage="Parola boş geçilemez")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-zA-Z])\w{8,}$",ErrorMessage="Şifreniz en az 8 karakter içermeli ve kompleks olmalıdır")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage="E-Posta adresinizi giriniz")] 
        [EmailAddress(ErrorMessage="E-Posta formatı geçerisiz")]
        public string Email { get; set; }
        public string ActivationCode { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public List<ShareDTO> Shares { get; set; }

        public List<UserImageDTO> UserImages { get; set; }

        public List<UserVideoDTO> UserVideos { get; set; }
    }
}
