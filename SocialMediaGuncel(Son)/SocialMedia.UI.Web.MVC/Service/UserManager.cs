using SocialMedia.DAL.Models.Data.Context;
using SocialMedia.DAL.Models.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.UI.Web.MVC.Service
{
    public class UserManager
    {
        public static AppUser currentUser
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var Email = HttpContext.Current.User.Identity.Name;

                    using (ProjectContext context = new ProjectContext())
                    {
                        var user = context.Users.FirstOrDefault(x => x.Email == Email);

                        return user;
                    }

                }

                return null;
            }
        }
    }
}