using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoomOfSon.Models.EF;
namespace RoomOfSon.Models.DAO
{
    public class MealDetailDAO
    {
        dbQLCT db = new dbQLCT();
        public DateTime datetime { get; set; }
        public string fullname { get; set; }
        public float money { get; set; }
        public string description { get; set; }
        public string actor { get; set; }
        public bool status { get; set; }
        public List<MealDetailDAO> GetList()
        {
            List<MealDetailDAO> tbl = new List<MealDetailDAO>();
            var temp = (from us in db.tblUsers
                        join md in db.tblUser_Meal on us.ID equals md.IDUser
                        join m in db.tblMeals on md.IDMeal equals m.ID
                        join a in db.tblUsers on m.IDActor equals a.ID
                        

                        orderby m.Datetime descending
                        select new
                        {
                            m.Datetime,
                            _user = us.Fullname,
                            m.Totalmoney,
                            m.Description,
                            _actor = a.Fullname,
                            md.Status
                        }
                 ).ToList();
            foreach (var it in temp)
            {
                MealDetailDAO s = new MealDetailDAO();
                s.datetime = (DateTime)it.Datetime;
                s.description = it.Description;
                s.fullname = it._user;
                s.money = float.Parse(it.Totalmoney.ToString());
                s.actor = it._actor;
                s.status = (bool)it.Status;
                tbl.Add(s);
            }
            return tbl;
        }
    }
}