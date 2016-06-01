using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DTO.Layer.Model
{
    public class ShareImageDTO:DTOBase
    {
        //kucuk foto
        public string ThumbnailUrl { get; set; }

        //orginal foto

        [Required(ErrorMessage = "Resim Boş geçilemez")]
        public string OrginalUrl { get; set; }

        public int ShareID { get; set; }
    }
}
