using SocialMedia.DAL.Models.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialMedia.DAL.ORM.Entity
{
    public class UserVideo:EntityBase
    {
        public string VideoURL { get; set; }
        public int UserID { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
