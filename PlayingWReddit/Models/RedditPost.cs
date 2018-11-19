using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayingWReddit.Models
{
    public class RedditPost
    {
        //model of the things I want from the reddit API
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string LinkURL { get; set; }
    }
}