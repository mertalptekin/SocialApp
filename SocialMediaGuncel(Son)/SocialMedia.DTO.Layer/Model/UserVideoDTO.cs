﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DTO.Layer.Model
{
    public class UserVideoDTO:DTOBase
    {
        [Required(ErrorMessage="Video seçimi yapmadınız")]
        public string VideoURL { get; set; }
        public int UserID { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
