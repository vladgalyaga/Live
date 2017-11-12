using Dal.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL
{
    public class Identifier : IKeyable<int>
    {
        public int Id { get; set; }
    }
}
