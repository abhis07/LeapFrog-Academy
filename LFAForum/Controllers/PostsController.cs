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
using LFAForum.Models.LFAForumViewModel;

namespace LFAForum.Controllers
{
    public class PostsController : Controller
    {
        private LFAForumContext db = new LFAForumContext();
        private PostRepository repPost;
        

        public PostsController()
        {
            repPost = new PostRepository(db);
        }
        // GET: Posts
        public ActionResult Index()
        {
            var post = new TopicPostViewModel();

             post.PostList = repPost.Read().ToList();
            return View(post);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postLi = new TopicPostViewModel();
            

            Post post = repPost.Read().FirstOrDefault(x => x.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.StatusID = new SelectList(db.Status, "Id", "Name");
            ViewBag.TopicID = new SelectList(db.Topics, "TopicId", "Subject");
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Subject,Context,Created,TopicID,UserID,StatusID")] Post post)
        {
            if (ModelState.IsValid)
            {
                repPost.Create(post);
                return RedirectToAction("Index");
            }

            ViewBag.StatusID = new SelectList(db.Status, "Id", "Name", post.StatusID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicId", "Subject", post.TopicID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", post.UserID);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = repPost.Read().FirstOrDefault(x => x.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusID = new SelectList(db.Status, "Id", "Name", post.StatusID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicId", "Subject", post.TopicID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", post.UserID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject,Context,Created,TopicID,UserID,StatusID")] Post post)
        {
            if (ModelState.IsValid)
            {
                repPost.Update(post);
                return RedirectToAction("Index");
            }
            ViewBag.StatusID = new SelectList(db.Status, "Id", "Name", post.StatusID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicId", "Subject", post.TopicID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", post.UserID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id); repPost.Read().FirstOrDefault(x => x.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = repPost.Read().FirstOrDefault(x => x.ID == id);
            repPost.Delete(post);
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
