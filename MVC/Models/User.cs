using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Role { get; set; }
        public bool IsActive { get; set; }
        public string UserConfirmed { get; set; }
        public string UserCode1 { get; set; }
        public string UserCode2 { get; set; }
    }
}