using Dal.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class Event : IKeyable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeOfConduction { get; set; }



        public City City { get; set; }
        public EventType EventType { get; set; }
    }
}
