using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanlytrungtamngoaingu.Models;

namespace Quanlytrungtamngoaingu.Controllers
{
    public class LoginEntityController : Controller
    {
        TTNNContext db = new TTNNContext();
        // GET: LoginEntity
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(HocVien hv)
        {
            if (ModelState.IsValid)
            {
                db.HocViens.Add(hv);
                db.SaveChanges();
            }
            return View(hv);
        }
    }
}