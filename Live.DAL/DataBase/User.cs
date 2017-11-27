using Dal.Core.Interfaces.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public partial class User : Identifier
    {
        public string Name { get; set; }
        public string Photo { get; set; }

        public City City { get; set; }

        public List<User> Frands { get; set; }
        public List<Happening> Events { get; set; }
        public List<Chat> Chats { get; set; }
        public List<Happening> CreatedEvents { get; set; }
    }
}
