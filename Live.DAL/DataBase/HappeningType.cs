﻿using Dal.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class HappeningType : Identifier
    {
        public string Name { get; set; }

        public virtual List<Happening> Events { get; set; }
    }
}
