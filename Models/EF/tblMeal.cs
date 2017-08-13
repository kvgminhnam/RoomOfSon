namespace RoomOfSon.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMeal")]
    public partial class tblMeal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMeal()
        {
            tblUser_Meal = new HashSet<tblUser_Meal>();
        }

        public int ID { get; set; }

        public DateTime? Datetime { get; set; }

        public double? Totalmoney { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? IDActor { get; set; }

        public bool? Status { get; set; }

        public virtual tblUser tblUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUser_Meal> tblUser_Meal { get; set; }
    }
}
