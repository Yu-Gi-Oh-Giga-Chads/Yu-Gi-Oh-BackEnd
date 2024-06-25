using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Deck
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Card> Cards { get; set; }
        public List<int> Copies { get; set; }
        public List<User> Users { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastEdited { get; set; }

        public Deck()
        {
            Users = new List<User>();
            Cards = new List<Card>();
            Copies = new List<int>();
            DateCreated = DateTime.Now;
            LastEdited = DateTime.Now;
        }

        public Deck(string name)
            : this()
        {
            Name = name;
        }
    }
}
