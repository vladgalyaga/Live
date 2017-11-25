namespace Live.DAL.DataBase
{
    using Dal.Core.Interfaces.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role: IdentityRole<int, UserRole>, IKeyable<int>
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Roles()
        //{
        //    Users = new HashSet<Users>();
        //}

        //public int Id { get; set; }

        //[Required]
        //[StringLength(256)]
        //public string Name { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Users> Users { get; set; }
    }
}
