using Dal.Core.Interfaces.Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class User : Identifier
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public City City { get; set; }

        public List<User> Frands { get; set; }
    }
}
