using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MVC.Models;

namespace MVC.Data
{
    public class LoginCheck
    {
        private DatabaseContext dbContext;

        public LoginCheck()
        {
            dbContext = new DatabaseContext();
        }

        public bool IsLoginSuccess(User userModel)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var user = dbContext.Users.Where(x => x.UserName == userModel.UserName).FirstOrDefault();

            if (user != null && user.IsActive == false && user.UserConfirmed == "1")
            {
                if (user.Password == crypto.Compute(userModel.Password, user.Salt))
                {
                    return true;
                }
            }

            return false;
        }
    }
}