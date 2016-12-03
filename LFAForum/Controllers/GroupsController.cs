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
    public class GroupsController : Controller
    {
        private LFAForumContext db = new LFAForumContext();
        private GroupRepository repGroup;

        public GroupsController()
        {
            repGroup = new GroupRepository(db);
        }

        // GET: Groups
        public ActionResult Index()
        {
            var groups = repGroup.Read().Include(g => g.Category);
            return View(groups.ToList());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = repGroup.Read().FirstOrDefault(x => x.ID == id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(repGroup.Read(), "Id", "Name");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CategoryID,CreatorId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(repGroup.Read(), "Id", "Name", group.CategoryID);
            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = repGroup.Read().FirstOrDefault(x => x.ID == id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(repGroup.Read(), "Id", "Name", group.CategoryID);
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CategoryID,CreatorId")] Group group)
        {
            if (ModelState.IsValid)
            {
                repGroup.Update(group);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(repGroup.Read(), "Id", "Name", group.CategoryID);
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = repGroup.Read().FirstOrDefault(x => x.ID == id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = repGroup.Read().FirstOrDefault(x => x.ID == id);
            repGroup.Delete(group);

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
