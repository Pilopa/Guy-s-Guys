using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Model.Entity
{
    public class User
    {
        public User() {}

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return Name.First().ToString().ToUpper() + Name.Substring(1);
        }
    }
}
