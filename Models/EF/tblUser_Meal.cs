namespace RoomOfSon.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUser_Meal
    {
        public int ID { get; set; }

        public int? IDMeal { get; set; }

        public int? IDUser { get; set; }

        public bool? Status { get; set; }

        public virtual tblMeal tblMeal { get; set; }

        public virtual tblUser tblUser { get; set; }
    }
}
