using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DTO.Layer.Model
{
    public class UserImageDTO:DTOBase
    {
        public string ThumbnailPath { get; set; }

        [Required( ErrorMessage="Lütfen profil resim seçiniz")]
        public string OrginalPath { get; set; }
        public int UserID { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
