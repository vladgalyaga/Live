namespace Live.DAL.DataBase
{
    using Dal.Core.Interfaces.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User : IdentityUser<int, Login, UserRole, UserClaim>, IKeyable<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            //Logins = new HashSet<Logins>();
            //UserClaims = new HashSet<UserClaims>();
            //Roles = new HashSet<Roles>();
        }

        //public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //[StringLength(256)]
        //public string Email { get; set; }

        //public bool EmailConfirmed { get; set; }

        //public string PasswordHash { get; set; }

        //public string SecurityStamp { get; set; }

        //public string PhoneNumber { get; set; }

        //public bool PhoneNumberConfirmed { get; set; }

        //public bool TwoFactorEnabled { get; set; }

        //public DateTime? LockoutEndDateUtc { get; set; }

        //public bool LockoutEnabled { get; set; }

        //public int AccessFailedCount { get; set; }

        //[Required]
        //[StringLength(256)]
        //public string UserName { get; set; }

        [StringLength(5)]
     //   [Column("CustomerId")]
        public string CustomerId { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Logins> Logins { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UserClaims> UserClaims { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Roles> Roles { get; set; }
    }
}
