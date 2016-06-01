using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DTO.Layer.Model
{
    public class ShareDTO:DTOBase
    {
        [Required(ErrorMessage= "Lütfen gönderiniz ile ilgili kısmı doldurunuz")]
        public string Post { get; set; }

        //gönderiye ait farklı kaynaklardaki url
        public string Location { get; set; }

        //Gönderiye ait resimler
        public ShareImageDTO ShareImage { get; set; }
        public ShareVideoDTO ShareVideo { get; set; }

        public AppUserDTO AppUser { get; set; }

        //Gönderiye ait yorumlar
        public List<CommentDTO> Comments { get; set; }

        //Gönderi kime ait
        public int AppUserID { get; set; }
    }
}
