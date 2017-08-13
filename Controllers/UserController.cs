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
    public class UserController : BaseController
    {
        dbQLCT db = new dbQLCT();
        // GET: User
        public ActionResult Index()
        {
            tblUser user = (tblUser)Session["User"];
            ViewBag.Avatar = user.Avatar;
            ViewBag.Fullname = user.Fullname;

            return View(db.tblUsers.ToList());
        }
        public ActionResult PaymentSubmit(int a,int? b)
        {
            Thread.Sleep(2000);
            var temp = db.tblUsers.FirstOrDefault(it => it.ID == a);
            if(temp == null)
            {
                return Content("Người dùng không tồn tại");
            }
            if (b <= 1000|| b == null)
            {
                return Content("Erro! Số tiền nộp sai!");
            }
            string res = "Nộp tiền thành công cho ";
            var actor = (tblUser)Session["User"];
            tblPayment pm = new tblPayment();
            pm.IDUser = a;
            pm.IDActor = actor.ID;
            pm.Money = b;
            pm.Status = false;
            pm.Datetime = DateTime.Now;
            db.tblPayments.Add(pm);
            db.SaveChanges();

            res += db.tblUsers.FirstOrDefault(i => i.ID == a).Fullname.ToString() + ": "+b.ToString() + ", hãy chờ người xác nhận!";
            
            return Content(res);
        }
        public ActionResult ConfirmPartialView()
        {
            var actor = (tblUser)Session["User"];
            ViewBag.IDActor = actor.ID;
            ConfirmPayment cfpm = new ConfirmPayment();

            return PartialView(cfpm.GetList(actor));
        }
        public ActionResult PaymentConfirm(int a)
        {
            var actor = (tblUser)Session["User"];
            var pm = db.tblPayments.FirstOrDefault(it => it.ID == a);
            if (actor.ID != pm.IDActor && actor.ID != pm.IDUser)
            {
                pm.Status = true;

                tblConfirm cf = new tblConfirm();
                cf.IDPayment = a;
                cf.IDResponsible = actor.ID;

                db.tblConfirms.Add(cf);
                db.SaveChanges();
                var uspay = db.tblUsers.FirstOrDefault(it => it.ID == pm.IDUser);
                uspay.Money += pm.Money;

                tblHistory htr = new tblHistory();
                htr.IDUser = pm.IDUser;
                htr.IDAction = 1;
                htr.IDActor = actor.ID;
                htr.Money = pm.Money;
                htr.Datetime = DateTime.Now;

                db.tblHistories.Add(htr);

                db.SaveChanges();

            }
            return Content("Successed!");
        }
        public ActionResult ConfirmMealPartialView()
        {
            var actor = (tblUser)Session["User"];
            ConfirmMealDAO cmdao = new ConfirmMealDAO();
            return PartialView(cmdao.GetList(actor));
        }
        public ActionResult MealConfirm(int a)
        {
            var actor = (tblUser)Session["User"];

            ConfirmMealDAO cmdao = new ConfirmMealDAO();
            cmdao.Confirm(a, actor.ID);

            return Content("Successed!");
        }
        public ActionResult tblInforUserPartialView()
        {
            return PartialView(db.tblUsers.ToList());
        }
    }
}