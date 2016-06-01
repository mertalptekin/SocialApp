using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialMedia.BL.DataService;
using SocialMedia.DAL.Models.Data.Entity;

namespace SocialMedia.BL.Test
{
    [TestClass]
    public class AppUserServiceTest
    {
        [TestMethod]
        public void AppUserDeleteTest()
        {
            AppUser user = new AppUser();
            user.ID = 5;


            AppUserService service = new AppUserService();
            service.Delete(user.ID);
            int result = service.Save();


            Assert.AreEqual(1, result);

        }
    }
}
