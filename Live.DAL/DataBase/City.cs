using Dal.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class City : Identifier
    {
        public string Name { get; set; }

        public Country Country { get; set; }
        
        public virtual List<User> Users { get; set; }
    }
}
