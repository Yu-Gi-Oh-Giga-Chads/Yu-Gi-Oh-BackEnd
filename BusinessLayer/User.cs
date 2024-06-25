using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<Deck> Decks { get; set; }
        public User()
        {
            Decks = new List<Deck>();
        }

        public User(string? userName, string? email, string? password)
            :this()
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public User(User user)
            :this()
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Password = user.Password;
        }
    }
}
