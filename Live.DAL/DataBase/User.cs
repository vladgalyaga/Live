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
      //  public DateTime DateOfBirth { get; set; }



    //    public virtual List<Friendship> Friendships { get; set; }
        public virtual ICollection<Happening> Events { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Happening> CreatedEvents { get; set; }
    }
}