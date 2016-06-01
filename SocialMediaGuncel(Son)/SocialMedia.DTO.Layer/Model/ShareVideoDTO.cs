using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DTO.Layer.Model
{
    public class ShareVideoDTO:DTOBase
    {
        public string IFrame { get; set; }
        public string VideoUrl { get; set; }

        public int ShareID { get; set; }
    }
}
