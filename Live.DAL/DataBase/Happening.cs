using Dal.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class Happening : Identifier
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime TimeOfConduction { get; set; }
        
        public City City { get; set; }
        public HappeningType EventType { get; set; }

        public List<User> Participants { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
