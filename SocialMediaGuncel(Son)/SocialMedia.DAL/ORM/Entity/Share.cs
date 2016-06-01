using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialMedia.DAL.Models.Data.Entity
{
    //gonderi silindiğinde gönderiye ait media içeriği yorum ve gönderi uçar
    public class Share:EntityBase
    {
        //gönderi yazısı
        public string Post { get; set; }

        //gönderiye ait farklı kaynaklardaki url
        public string Location { get; set; }

        public List<Comment> Comments { get; set; }

        //Gönderi kime ait
        public int AppUserID { get; set; }





        //protected override bool Validate()
        //{
        //    throw new NotImplementedException();
        //}
    }
}