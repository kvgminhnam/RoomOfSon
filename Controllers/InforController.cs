using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomOfSon.Models.EF;

namespace RoomOfSon.Controllers
{
    public class InforController : BaseController
    {
        // GET: Infor
        public ActionResult Index()
        {
            tblUser us = (tblUser)Session["User"];
            ViewBag.Avatar = us.Avatar;
            ViewBag.Fullname = us.Fullname;
            return View();
        }
    }
}