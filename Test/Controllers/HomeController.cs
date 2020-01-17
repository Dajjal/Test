using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                List<ReviewItem> list = db.Reviews.Select(q => new ReviewItem()
                {
                    ID = q.ID,
                    ClientName = q.ClientName,
                    Review = q.Review
                }).ToList();
                PageModel model = new PageModel()
                {
                    ListModel = list,
                    MetaModel = new ReviewItem()
                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Create(PageModel model)
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                Reviews rec = new Reviews()
                {
                    ClientName = model.MetaModel.ClientName,
                    Review = model.MetaModel.Review
                };
                db.Reviews.Add(rec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Async()
        {
            return View();
        }
    }
}