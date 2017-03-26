using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Model
{
    public class User
    {
        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public string Name { get; set; }
        public string Password { get; set; }
    }
}
