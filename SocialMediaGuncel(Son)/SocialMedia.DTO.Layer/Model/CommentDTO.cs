using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DTO.Layer.Model
{
    public class CommentDTO:DTOBase
    {
        [Required(ErrorMessage = "Mesaj boş geçilemez")]
        public string Message { get; set; }
        public DateTimeOffset LocalTime { get; set; }
        public int AppUserID { get; set; }
    }
}
