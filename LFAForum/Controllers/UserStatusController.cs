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
    public class UserStatusController : Controller
    {
        private LFAForumContext db = new LFAForumContext();
        private UserStatusRepository repUsrStatus;

        public UserStatusController()
        {
            repUsrStatus = new UserStatusRepository(db);
        }

        // GET: UserStatu
        public ActionResult Index()
        {
            return View(repUsrStatus.Read().ToList());
        }

        // GET: UserStatu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStatu UserStatu = repUsrStatus.Read().FirstOrDefault(x => x.ID == id);
            if (UserStatu == null)
            {
                return HttpNotFound();
            }
            return View(UserStatu);
        }

        // GET: UserStatu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserStatu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserStatuId,Name")] UserStatu UserStatu)
        {
            if (ModelState.IsValid)
            {
                repUsrStatus.Create(UserStatu);
                return RedirectToAction("Index");
            }

            return View(UserStatu);
        }

        // GET: UserStatu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStatu UserStatu = repUsrStatus.Read().FirstOrDefault(x => x.ID == id);
            if (UserStatu == null)
            {
                return HttpNotFound();
            }
            return View(UserStatu);
        }

        // POST: UserStatu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserStatuId,Name")] UserStatu UserStatu)
        {
            if (ModelState.IsValid)
            {
                repUsrStatus.Update(UserStatu);
                return RedirectToAction("Index");
            }
            return View(UserStatu);
        }

        // GET: UserStatu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStatu UserStatu = repUsrStatus.Read().FirstOrDefault(x => x.ID == id);
            if (UserStatu == null)
            {
                return HttpNotFound();
            }
            return View(UserStatu);
        }

        // POST: UserStatu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserStatu UserStatu = repUsrStatus.Read().FirstOrDefault(x => x.ID == id);
            repUsrStatus.Delete(UserStatu);
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
