using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL
{
    public class Context : DbContext
    {
        public Context() : base("DbConnection")
        { }

        DbSet<Assessment> Assessments { get; set; }
        DbSet<Chat> Chats { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<EventType> EventTypes { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<User> Users { get; set; }
    }
}
