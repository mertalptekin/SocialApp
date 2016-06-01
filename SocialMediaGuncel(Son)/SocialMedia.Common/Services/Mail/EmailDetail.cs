using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialMedia.Common.Services.Mail
{
    public class EmailDetail
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }


    }
}
