namespace RoomOfSon.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAdmin")]
    public partial class tblAdmin
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
    }
}
