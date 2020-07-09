using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanlytrungtamngoaingu.Models;
using PagedList;
using PagedList.Mvc;

namespace Quanlytrungtamngoaingu.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        TTNNContext db = new TTNNContext();
        public ActionResult Index()
        {
            return View(db.KhoaHocs.Take(6).ToList());
        }
    }
}