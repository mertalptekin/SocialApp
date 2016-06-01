using SocialMedia.DAL.Models.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialMedia.DAL.ORM.Entity
{
    public class UserImage:EntityBase
    {
        public string ThumbnailPath { get; set; }
        public string OrginalPath { get; set; }
        public int UserID { get; set; }
        public List<Comment> Comments { get; set; }


    }
}
