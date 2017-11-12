using Dal.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class Rating : Identifier
    {
        public int Weigth { get; set; }

        public User User { get; set; }
       

    }
}
