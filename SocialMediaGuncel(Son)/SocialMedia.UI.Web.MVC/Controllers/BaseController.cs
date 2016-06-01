using SocialMedia.BL.DataService;
using SocialMedia.DAL.Models.Data.Entity;
using SocialMedia.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.UI.Web.MVC.Controllers
{
    public class BaseController : Controller
    {
        //protected BaseRepository<Share> shareService;
        //protected BaseRepository<ShareVideo> shareVideoService;
        //protected BaseRepository<ShareImage> shareImageService;
        //protected BaseRepository<AppUser> appUserService;
        //protected BaseRepository<UserImage> appUserImageService;
        //protected BaseRepository<UserVideo> appUserVideoService;
        //protected BaseRepository<Comment> commentService;

      protected  UnitOfWork unitOfWork;

        public BaseController()
        {
            unitOfWork = new UnitOfWork();
            //shareImageService = new BaseRepository<ShareImage>();
            //shareVideoService = new BaseRepository<ShareVideo>();
            //shareService = new BaseRepository<Share>();
            //appUserVideoService = new BaseRepository<UserVideo>();
            //appUserImageService = new BaseRepository<UserImage>();
            //commentService = new BaseRepository<Comment>();
            //appUserService = new BaseRepository<AppUser>();
        }


        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose(disposing);

        }
       
	}
}