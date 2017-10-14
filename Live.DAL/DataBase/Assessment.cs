using Dal.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class Assessment : IKeyable<int>
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }

        public User Appraiser { get; set; }
        public User Estimated { get; set; }
    }
}
