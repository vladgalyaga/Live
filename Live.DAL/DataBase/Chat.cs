using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class Chat : Identifier
    {


        public string Name { get; set; }
        public User Creator { get; set; }

        public List<User> Users { get; set; }


    }
}
