using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.DAL.Models.Data.Entity
{
    public class Comment:EntityBase
    {
        public string Message { get; set; }

        //Local Tarih Saat
        public DateTimeOffset LocalTime { get; set; }
        public int AppUserID { get; set; }

    }
}