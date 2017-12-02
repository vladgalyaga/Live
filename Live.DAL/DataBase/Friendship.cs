using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class Friendship : Identifier
    {
        public int User2_Id { get; set; }
        public int User1_Id { get; set; }
        public bool Сonfirmation { get; set; }

    }
}
