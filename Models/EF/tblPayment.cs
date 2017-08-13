namespace RoomOfSon.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPayment")]
    public partial class tblPayment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPayment()
        {
            tblConfirms = new HashSet<tblConfirm>();
        }

        public int ID { get; set; }

        public int? IDUser { get; set; }

        public int? IDActor { get; set; }

        public double? Money { get; set; }

        public DateTime? Datetime { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblConfirm> tblConfirms { get; set; }

        public virtual tblUser tblUser { get; set; }

        public virtual tblUser tblUser1 { get; set; }
    }
}
