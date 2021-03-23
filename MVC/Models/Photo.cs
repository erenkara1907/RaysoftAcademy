using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    [Table("Photos")]
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}