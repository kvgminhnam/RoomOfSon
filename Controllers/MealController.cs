using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomOfSon.Models.EF;
using RoomOfSon.Models.DAO;
using System.Threading;

namespace RoomOfSon.Controllers
{
    public class MealController : BaseController
    {
        // GET: Meal
        dbQLCT db = new dbQLCT();
        [HttpGet]
        public ActionResult Index()
        {

            tblUser user = (tblUser)Session["User"];
            ViewBag.Avatar = user.Avatar;
            ViewBag.Fullname = user.Fullname;

            UserCheckedDAO ucd = new UserCheckedDAO();

            return View(ucd.GetList());
        }
        [HttpPost]
        public ActionResult SubmitMeal(List<UserCheckedDAO> us, FormCollection f)
        {
            Thread.Sleep(2000);
            int sl = us.Count(i => i.IsChecked == true);
            float money = float.Parse(f.Get("money").ToString());
            string des = f.Get("description");
            string res = "";
            tblUser actor = (tblUser)Session["User"];

            if (money % 1000 != 0 || money < 1000)
            {
                return Content("Erro! Nhập tiền sai! ");
            }

            tblMeal meal = new tblMeal();
            meal.Datetime = DateTime.Now;
            meal.Totalmoney = money;
            meal.Description = des;
            meal.IDActor = actor.ID;
            meal.Status = false;

            db.tblMeals.Add(meal);
            db.SaveChanges();

            

            foreach(UserCheckedDAO it in us)
            {
                if (it.IsChecked)
                {                    
                    var tempu = db.tblUsers.FirstOrDefault(i => i.ID == it.UserChecked.ID);

                    tblUser_Meal um = new tblUser_Meal();
                    um.IDMeal = meal.ID;
                    um.IDUser = it.UserChecked.ID;
                    um.Status = false;
                    db.tblUser_Meal.Add(um);
                    db.SaveChanges();

                    res += " "+ tempu.Fullname;
                }
                
            }
            res+="trung bình: "+ money / sl;
           
            return Content("Gửi yêu cầu tính tiền cho: "+res);
        }
        public ActionResult GettblMealPartialView()
        {
            MealDetailDAO mdao = new MealDetailDAO();
            var tbl = mdao.GetList();
            return PartialView(tbl);
        }
    }
}