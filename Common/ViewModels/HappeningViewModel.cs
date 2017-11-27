using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class HappeningViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime TimeOfConduction { get; set; }

        public string City { get; set; }
        public string EventType { get; set; }
        public int CreaterId { get; set; }
        
    }
}
