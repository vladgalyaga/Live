using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL
{
    public class LiveContext : DbContext
    {
        public LiveContext() : base("DbConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chat>()
                  .HasMany(t => t.Users)
                   .WithMany(t => t.Chats);

            modelBuilder.Entity<User>()
               .HasMany(t => t.Events)
                .WithMany(t => t.Participants);

            modelBuilder.Entity<User>()
            .HasMany(t => t.CreatedEvents)
             .WithOptional(t => t.Creater);




        }

        DbSet<Assessment> Assessments { get; set; }
        DbSet<Chat> Chats { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Happening> Events { get; set; }
        DbSet<HappeningType> EventTypes { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Friendship> Friendships { get; set; }
    }
}
