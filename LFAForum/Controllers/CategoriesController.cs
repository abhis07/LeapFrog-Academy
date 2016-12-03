using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GR.LFAForum.Repository;
using LFAForum.Repo.Data;

namespace LFAForum.Controllers
{
    public class CategoriesController : Controller
    {
        private LFAForumContext db = new LFAForumContext();
        private CategoryRepository repCategory;



        public CategoriesController()
        {
            repCategory = new CategoryRepository(db);                           // ur = new UserRepository(db);
        }

       
        // GET: Categories
        public ActionResult Index()
        {
            TempData["GetCatNames"] = "Robot";
            return View(repCategory.Read().ToList());
        }

        //public ActionResult GetCat()
        //{
        //    var  apple = "Hello";
        //    return View(apple);
        //}

        // GET: Categories/Details/5
        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = repCategory.Read().FirstOrDefault(x => x.ID == ID);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.ParentCategoryID = new SelectList(repCategory.Read(), "ID", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkID=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Creator,Created,StatusID,ParentCategoryID")] Category category)
        {
            if (ModelState.IsValid)
            {
                repCategory.Create(category);

                return RedirectToAction("Index");
            }

            ViewBag.ParentCategoryID = new SelectList(repCategory.Read(), "ID", "Name", category.ParentCategoryID);
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = repCategory.Read().FirstOrDefault(x => x.ID == ID);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentCategoryID = new SelectList(repCategory.Read(), "ID", "Name", category.ParentCategoryID);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkID=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Creator,Created,StatusID,ParentCategoryID")] Category category)
        {
            if (ModelState.IsValid)
            {
                repCategory.Update(category);
                return RedirectToAction("Index");
            }
            ViewBag.ParentCategoryID = new SelectList(repCategory.Read(), "ID", "Name", category.ParentCategoryID);
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = repCategory.Read().FirstOrDefault(x => x.ID == ID);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ID)
        {
            Category category = repCategory.Read().FirstOrDefault(x => x.ID == ID);
            repCategory.Delete(category);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
