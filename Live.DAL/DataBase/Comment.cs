﻿using Dal.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.DAL.DataBase
{
    public class Comment : IKeyable<int>
    {
        public int Id { get; set; }
        public string Descriprion { get; set; }


    }
}