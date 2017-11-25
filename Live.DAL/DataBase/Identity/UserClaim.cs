namespace Live.DAL.DataBase
{
    using Dal.Core.Interfaces.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserClaim : IdentityUserClaim<int>,IKeyable<int>
    {
        //public int Id { get; set; }

        //public int UserId { get; set; }

        //public string ClaimType { get; set; }

        //public string ClaimValue { get; set; }

        //public virtual Users Users { get; set; }
    }
}
