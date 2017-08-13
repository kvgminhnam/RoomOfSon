using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomOfSon.Models.EF;
using RoomOfSon.Common;

namespace RoomOfSon.Controllers
{
    public class AddMemberController : BaseController
    {
        // GET: AddMember
        dbQLCT db = new dbQLCT();
        public ActionResult Index()
        {
            tblUser us = (tblUser)Session["User"];
            ViewBag.Avatar = us.Avatar;
            ViewBag.Fullname = us.Fullname;
            return View();
        }
        
        public ActionResult SubmitAddMember(string a, string b, string c, string d, string e)
        {

            var se = db.tblUsers.FirstOrDefault(it => it.Username == a);
            if(se == null)
            {
                if(b == c)
                {
                    tblUser us = new tblUser();
                    us.Username = a;
                    us.Password = Encryptor.MD5Hash(b);
                    us.Fullname = d;
                    us.Money = 0;
                    if(e == "") us.Avatar = "http://2.pik.vn/20171198b814-3514-4d5b-967c-73ec0d448453.jpg";
                    else us.Avatar = e;

                    db.tblUsers.Add(us);
                    db.SaveChanges();
                    return Content("Thêm thành công!");
                }
                else
                {
                    return Content("Erro! Mật khẩu xác nhận không đúng!");
                }
            }
            else
            {
                return Content("Erro! Username đã được sử dụng!");
            }
            
        }
    }
}