namespace Live.DAL.DataBase
{
    using Dal.Core.Interfaces.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Login : IdentityUserLogin<int>, IKeyable<int>
    {
        //[Key]
        //[Column(Order = 0)]
        //public string LoginProvider { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //public string ProviderKey { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int UserId { get; set; }

        //public virtual Users Users { get; set; }

        public int Id { get { return UserId; } }
    }
}
