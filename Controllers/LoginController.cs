using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomOfSon.Models.EF;
using RoomOfSon.Common;

namespace RoomOfSon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        dbQLCT db = new dbQLCT();
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Login(string username, string password)
        {

            string pass = Encryptor.MD5Hash(password);
            if (ModelState.IsValid)
            {
                var res = db.tblUsers.FirstOrDefault(us => us.Username == username && us.Password == pass);
                if (res!= null)
                {
                    Session["User"] = res;
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại!");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}