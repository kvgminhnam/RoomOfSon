using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoomOfSon.Models.EF;

namespace RoomOfSon.Models.DAO
{
    
    public class ConfirmMealDAO
    {
        dbQLCT db = new dbQLCT();
        public int ID { get; set; }
        public DateTime datetime { get; set; }
        public float totalmoney { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public int numofpe { get; set; }

        public List<ConfirmMealDAO> GetList(tblUser confirmer)
        {
            List<ConfirmMealDAO> ListMealConfirm = new List<ConfirmMealDAO>();
            var temp = (from m in db.tblMeals
                        join um in db.tblUser_Meal on m.ID equals um.IDMeal
                        where um.IDUser == confirmer.ID
                        orderby m.Datetime descending
                        select new
                        {
                            um.ID,
                            m.Datetime,
                            m.Totalmoney,
                            m.Description,
                            um.Status,
                            um.IDMeal
                        }
                        ).ToList();
            foreach(var it in temp)
            {
                ConfirmMealDAO cmdao = new ConfirmMealDAO();
                cmdao.ID = it.ID;
                cmdao.datetime = (DateTime)it.Datetime;
                cmdao.description = it.Description;
                cmdao.totalmoney = (float)it.Totalmoney;
                cmdao.status = (bool)it.Status;
                cmdao.numofpe = db.tblUser_Meal.Count(i => i.IDMeal == it.IDMeal);

                ListMealConfirm.Add(cmdao);
            }
            return ListMealConfirm;
        }
        public void Confirm(int IDUser_Meal, int IDActor)
        {
            var temp = db.tblUser_Meal.FirstOrDefault(it => it.ID == IDUser_Meal && it.Status == false);
            if (temp != null)
            {
                temp.Status = true;
                db.SaveChanges();
            }
            else return;
            if(db.tblUser_Meal.Count(it => it.IDMeal == temp.IDMeal) == db.tblUser_Meal.Count(it => it.IDMeal == temp.IDMeal && it.Status == true))
            {
                AfterFullConfirm(IDUser_Meal, IDActor);
            }
        }
        public void AfterFullConfirm(int IDUser_Meal, int IDActor)
        {
            var temp = db.tblUser_Meal.FirstOrDefault(it => it.ID == IDUser_Meal);
            var meal = db.tblMeals.FirstOrDefault(it => it.ID == temp.IDMeal);
            var usm = db.tblUser_Meal.Where(it => it.IDMeal == meal.ID);
            //int num = db.tblUser_Meal.Count(it => it.IDMeal == meal.ID);
            meal.Status = true;
            db.SaveChanges();

            foreach(var it in usm)
            {
                tblHistory htr = new tblHistory();
                htr.IDUser = it.IDUser;
                htr.IDAction = 2;
                htr.Money = meal.Totalmoney / usm.Count();
                htr.Datetime = (DateTime)meal.Datetime;
                htr.IDActor = IDActor;

                db.tblHistories.Add(htr);
               

                var us = db.tblUsers.FirstOrDefault(i => i.ID == it.IDUser);
                us.Money -= htr.Money;


            }

            db.SaveChanges();
        }
    }
}