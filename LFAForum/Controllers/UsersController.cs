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
    public class UsersController : Controller
    {
        private LFAForumContext db = new LFAForumContext();
        private UserRepository repUser;

        public UsersController()
        {
            repUser = new UserRepository(db);
        }
        // GET: Users
        public ActionResult Index()
        {
            var users = repUser.Read().Include(u => u.UserStatu);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = repUser.Read().FirstOrDefault(x => x.ID == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.UserStatus = new SelectList(repUser.Read(), "UserStatusId", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,FirstName,LastName,Created,LastActivity,IsModeratorId,UserStatus,HashPassword,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserStatus = new SelectList(repUser.Read(), "UserStatusId", "Name", user.UserStatus);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = repUser.Read().FirstOrDefault(x => x.ID == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserStatus = new SelectList(repUser.Read(), "UserStatusId", "Name", user.UserStatus);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,FirstName,LastName,Created,LastActivity,IsModeratorId,UserStatus,HashPassword,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                repUser.Update(user);
                return RedirectToAction("Index");
            }
            ViewBag.UserStatus = new SelectList(repUser.Read(), "UserStatusId", "Name", user.UserStatus);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = repUser.Read().FirstOrDefault(x => x.ID == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = repUser.Read().FirstOrDefault(x => x.ID == id);
            repUser.Delete(user);
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
