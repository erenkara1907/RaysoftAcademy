using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    [Table("Articles")]
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateAdded { get; set; }
        public string Photo { get; set; }

        public List<Photo> Photos { get; set; }

        public Article()
        {
            Photos = new List<Photo>();
        }
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public System.Data.Entity.DbSet<MVC.Models.Photo> Photos { get; set; }
        public System.Data.Entity.DbSet<MVC.Models.User> Users { get; set; }
    }
}