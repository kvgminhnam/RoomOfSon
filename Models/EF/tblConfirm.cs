namespace RoomOfSon.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblConfirm")]
    public partial class tblConfirm
    {
        public int ID { get; set; }

        public int? IDPayment { get; set; }

        public int? IDResponsible { get; set; }

        public virtual tblPayment tblPayment { get; set; }

        public virtual tblUser tblUser { get; set; }
    }
}
