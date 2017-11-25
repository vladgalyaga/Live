namespace Live.DAL.DataBase
{
    using Dal.Core.Interfaces.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole : IdentityUserRole<int>, IKeyable<int>
    {
        //[Key]
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int UserId { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int RoleId { get; set; }


        public int Id { get { return UserId; } }
    }
}
