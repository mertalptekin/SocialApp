using SocialMedia.BL.DataService;
using SocialMedia.DAL.Models.Data.Entity;
using SocialMedia.DTO.Layer.Model;
using SocialMedia.UI.Web.MVC.Attribute;
using SocialMedia.UI.Web.MVC.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.UI.Web.MVC.Controllers
{
    [AuthenticationControl]
    public class HomeController : BaseController
    {
        //Butun gönderiler listelenicek
        private ShareService _shareService;
        private ShareImageService _shareImageService;
        private ShareVideoService _shareVideoService;
        private AppUserService _appUserService;

        public HomeController()
        {
            _shareService = unitOfWork.ShareService;
            _shareVideoService = unitOfWork.ShareVideoService;
            _shareImageService = unitOfWork.ShareImageService;
            _appUserService = unitOfWork.AppUserService;

        }
  
        public ActionResult Index()
        {

            ViewBag.UserName = HttpContext.User.Identity.Name;

            return View();
        }

        [ValidateAntiForgeryToken][HttpPost]
        public ActionResult AddPost(ShareDTO model,HttpPostedFileBase media)
        {

            bool _IsUploaded = false;
            bool _IsPicture = false;

            var virtualPath = "";
            string filename = "";

            List<string> allowedImageExtention = new List<string>();
            allowedImageExtention.Add("image/jpeg");
            allowedImageExtention.Add("image/png");

            List<string> allowedVideoExtention = new List<string>();
            allowedVideoExtention.Add("video/mp4");
            allowedVideoExtention.Add("video/wmv");


            if (media!=null)
            {
                if (allowedVideoExtention.Contains(media.ContentType))
                {
                    //videodur

                    virtualPath = "~/ShareMedia/Video/";
                    filename = Guid.NewGuid().ToString() + Path.GetExtension(media.FileName);
                    var physicalPath = HttpContext.Server.MapPath(virtualPath) + filename;
                   

                    if (System.IO.File.Exists(physicalPath))
                    {
                        ViewBag.Message = "Bu isimde dosya mevcut.Lütfen ismi değiştiriniz";
                    }
                    else
                    {
                        try
                        {
                            media.SaveAs(physicalPath);
                            _IsUploaded = true;
                            ViewBag.Message = "Video Kaydedildi";
                        }
                        catch (Exception)
                        {

                            ViewBag.Message = "Video yüklenirken hata oluştu. Tekrar deniyiniz";
                        }

                    }

                }
                else if (allowedImageExtention.Contains(media.ContentType))
                {
                    virtualPath = "~/ShareMedia/Image/Orginal/";
                    
                     filename = Guid.NewGuid().ToString() + Path.GetExtension(media.FileName);
                    var physicalPath = HttpContext.Server.MapPath(virtualPath) +filename;

                    if (System.IO.File.Exists(physicalPath))
                    {
                        ViewBag.Message = "Bu isimde resim mevcut.Lütfen ismi değiştiriniz";
                    }
                    else
                    {
                        try
                        {
                            _IsUploaded = true;
                            _IsPicture = true;
                            media.SaveAs(physicalPath);
                            ViewBag.Message = "Resim Kaydedildi";
                        }
                        catch (Exception)
                        {

                            ViewBag.Message = "Resim yüklenirken hata oluştu. Tekrar deniyiniz";
                        }

                    }
                }
                else
                {
                    ViewBag.Message = "Media içeriği jpg,png,mp4,mpv formatlarından birine sahip olmalıdır";
                }            
            }

            if (ModelState.IsValid)
            {
                Share share = new Share();
                share.Location = model.Location;
                share.Post = model.Post;
                share.AppUserID = UserManager.currentUser.ID;

                _shareService.Insert(share);
                _shareService.Save();


                if (media!=null)
                {
                    ShareImage image = new ShareImage();
                    image.OrginalUrl = _IsPicture == true ? virtualPath.Replace("~","") + filename : null;
                    image.ShareID = share.ID;
                   _shareImageService.Insert(image);
                    _shareImageService.Save();

                    ShareVideo video = new ShareVideo();
                    video.VideoUrl = _IsPicture == false ? virtualPath.Replace("~","") + filename : null;
                    video.ShareID = share.ID;
                    _shareVideoService.Insert(video);
                    _shareVideoService.Save();

                    ViewBag.Message = "Gönderiniz TimeLine da Paylaşıldı";


                }

                return Redirect("/Home/MyPost");
            }

            return View();
        }

        [HttpPost]
        public JsonResult AddShare(ShareDTO model, HttpPostedFileBase media)
        {
            bool _IsUploaded = false;
            bool _IsPicture = false;

            var virtualPath = "";
            string filename = "";

            List<string> allowedImageExtention = new List<string>();
            allowedImageExtention.Add("image/jpeg");
            allowedImageExtention.Add("image/png");

            List<string> allowedVideoExtention = new List<string>();
            allowedVideoExtention.Add("video/mp4");
            allowedVideoExtention.Add("video/wmv");


            if (media != null)
            {
                if (allowedVideoExtention.Contains(media.ContentType))
                {
                    //videodur

                    virtualPath = "~/ShareMedia/Video/";
                    filename = Guid.NewGuid().ToString() + Path.GetExtension(media.FileName);
                    var physicalPath = HttpContext.Server.MapPath(virtualPath) + filename;


                    if (System.IO.File.Exists(physicalPath))
                    {
                        ViewBag.Message = "Bu isimde dosya mevcut.Lütfen ismi değiştiriniz";
                    }
                    else
                    {
                        try
                        {
                            media.SaveAs(physicalPath);
                            _IsUploaded = true;
                            ViewBag.Message = "Video Kaydedildi";
                        }
                        catch (Exception)
                        {

                            ViewBag.Message = "Video yüklenirken hata oluştu. Tekrar deniyiniz";
                        }

                    }

                }
                else if (allowedImageExtention.Contains(media.ContentType))
                {
                    virtualPath = "~/ShareMedia/Image/Orginal/";

                    filename = Guid.NewGuid().ToString() + Path.GetExtension(media.FileName);
                    var physicalPath = HttpContext.Server.MapPath(virtualPath) + filename;

                    if (System.IO.File.Exists(physicalPath))
                    {
                        ViewBag.Message = "Bu isimde resim mevcut.Lütfen ismi değiştiriniz";
                    }
                    else
                    {
                        try
                        {
                            _IsUploaded = true;
                            _IsPicture = true;
                            media.SaveAs(physicalPath);
                            ViewBag.Message = "Resim Kaydedildi";
                        }
                        catch (Exception)
                        {

                            ViewBag.Message = "Resim yüklenirken hata oluştu. Tekrar deniyiniz";
                        }

                    }
                }
                else
                {
                    ViewBag.Message = "Media içeriği jpg,png,mp4,mpv formatlarından birine sahip olmalıdır";
                }
            }

            if (ModelState.IsValid)
            {
                Share share = new Share();
                share.Location = model.Location;
                share.Post = model.Post;
                share.AppUserID = UserManager.currentUser.ID;

                _shareService.Insert(share);
                _shareService.Save();


                if (media != null)
                {
                    ShareImage image = new ShareImage();
                    image.OrginalUrl = _IsPicture == true ? virtualPath.Replace("~", "") + filename : null;
                    image.ShareID = share.ID;
                    _shareImageService.Insert(image);
                    _shareImageService.Save();

                    ShareVideo video = new ShareVideo();
                    video.VideoUrl = _IsPicture == false ? virtualPath.Replace("~", "") + filename : null;
                    video.ShareID = share.ID;
                    _shareVideoService.Insert(video);
                    _shareVideoService.Save();

                    ViewBag.Message = "Gönderiniz TimeLine da Paylaşıldı";


                }

                var shareDto = _shareService.SelectMany(x => x.AppUserID == UserManager.currentUser.ID && x.ID == share.ID).Select(a => new ShareDTO
                {
                    AppUserID = a.AppUserID,
                    ID = a.ID,
                    Post = a.Post,
                    Location = a.Location,
                    AppUser = _appUserService.SelectMany(z => z.ID == a.AppUserID).Select(u => new AppUserDTO()
                    {
                        ID = u.ID,
                        ProfilePhotoUrl = u.ProfilePhotoUrl,
                        UserName = u.UserName

                    }).FirstOrDefault(),
                    ShareImage = _shareImageService.SelectMany(f => f.ShareID == a.ID).Select(k => new ShareImageDTO
                    {
                        OrginalUrl = k.OrginalUrl
                    }).FirstOrDefault(),
                    ShareVideo = _shareVideoService.SelectMany(g => g.ShareID == a.ID).Select(v => new ShareVideoDTO
                    {
                        VideoUrl = v.VideoUrl

                    }).FirstOrDefault()


                }).FirstOrDefault();

                return Json(shareDto);
            }

            return Json(new ShareDTO { });

        }

        public ActionResult MyPost()
        {
            var share = _shareService.SelectMany(x => x.AppUserID == UserManager.currentUser.ID).Select(a => new ShareDTO
            {
                AppUserID = a.AppUserID,
                ID = a.ID,
                Post = a.Post,
                Location = a.Location,
                AppUser = _appUserService.SelectMany(z => z.ID == a.AppUserID).Select(u => new AppUserDTO()
                {
                    ID = u.ID,
                    ProfilePhotoUrl = u.ProfilePhotoUrl,
                    UserName = u.UserName

                }).FirstOrDefault(),
                ShareImage = _shareImageService.SelectMany(f => f.ShareID == a.ID).Select(k => new ShareImageDTO
                {
                    OrginalUrl = k.OrginalUrl
                }).FirstOrDefault(),
                ShareVideo = _shareVideoService.SelectMany(g => g.ShareID == a.ID).Select(v => new ShareVideoDTO
                {
                    VideoUrl = v.VideoUrl

                }).FirstOrDefault()


            }).OrderByDescending(c=> c.ID).ToList();

            


            //kendi post ettikleri bulmam lazım ve viewe göndermem lazım;
            return View(share);
        }



	}
}