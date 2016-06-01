using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SocialMedia.DAL.Models.Data.Entity
{
    public class ShareImage:EntityBase
    {

        public int ShareID { get; set; }
        //kucuk foto
        public string ThumbnailUrl { get; set; }

        //orginal foto
        public string OrginalUrl { get; set; }



    }
}
