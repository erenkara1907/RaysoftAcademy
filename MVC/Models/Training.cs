using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Training
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Instructor { get; set; }
        public DateTime DateAdded { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}