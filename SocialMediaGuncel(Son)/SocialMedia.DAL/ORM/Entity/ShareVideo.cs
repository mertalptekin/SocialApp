using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SocialMedia.DAL.Models.Data.Entity
{
    public class ShareVideo:EntityBase
    {
        public string IFrame { get; set; }
        public string VideoUrl { get; set; }

        public int ShareID { get; set; }

    }
}
