namespace RoomOfSon.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHistory")]
    public partial class tblHistory
    {
        public int ID { get; set; }

        public int? IDUser { get; set; }

        public int? IDAction { get; set; }

        public double? Money { get; set; }

        public DateTime? Datetime { get; set; }

        public int? IDActor { get; set; }

        public virtual tblAction tblAction { get; set; }

        public virtual tblUser tblUser { get; set; }

        public virtual tblUser tblUser1 { get; set; }
    }
}
