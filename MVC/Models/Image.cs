using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int ArticleId { get; set; }
        public string ImagePath { get; set; }

        public Article Article { get; set; }
    }
}