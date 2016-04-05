using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class User
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public User(string pName, string pEmail, string pPassword)
        {
            Name = pName;
            Email = pEmail;
            Password = pPassword;
        }
    }
}
