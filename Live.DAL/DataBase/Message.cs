using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class Message : Identifier
    {
        public string Text { get; set; }
        
        public Chat Chat { get; set; }
        public User Author { get; set; }
    }
}
