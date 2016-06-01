using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialMedia.DAL.ORM.Entity;

namespace SocialMedia.DAL.Models.Data.Entity
{
    public class AppUser:EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ActivationCode { get; set; }
        //profil resmim
        public string ProfilePhotoUrl { get; set; }
        //kullanıcının paylaşımları
        public List<Share> Shares { get; set; }

        public List<UserImage> UserImages { get; set; }

        public List<UserVideo> UserVideos { get; set; }

        //protected override bool Validate()
        //{
        //    if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Password))
        //    {
        //        return  false;
        //    }


        //    if (Password.Length < 8 || !Email.Contains("@"))
        //    {
        //        return false;
        //    }
              

        //    return true;

        //}
    }
}