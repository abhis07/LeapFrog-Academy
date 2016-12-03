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
using LFAForum.Models;
using LFAForum.Models.LFAForumViewModel;

namespace LFAForum.Controllers
{
    public class TopicsController : Controller
    {
        private LFAForumContext db = new LFAForumContext();
        private TopicRepository repTopic;
        private PostRepository repPost;
        private CommentRepository repComment;

        public TopicsController()
        {
            repTopic = new TopicRepository(db);
            repPost = new PostRepository(db);
            repComment = new CommentRepository(db);

        }

        // GET: Topics
        public ActionResult Index()
        {

            var tp = new TopicPostViewModel();

            tp.TopicList = repTopic.Read().ToList();
            tp.PostList = repPost.Read().ToList();
            return View(tp);
        }

        // GET: Topics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var topic = new TopicPostViewModel();
            topic.TopicList = repTopic.Read().Where(x => x.ID == id).ToList();
            topic.PostList = repPost.Read().ToList();
            topic.CommentList = repComment.Read().ToList();

            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }


        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "ID,UsersID")] Comments comment, int? id)
        {
            if (ModelState.IsValid)
            {
                repComment.Create(comment);
                return RedirectToAction("Index");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var topic = new TopicPostViewModel();
            topic.TopicList = repTopic.Read().Where(x => x.ID == id).ToList();
            topic.PostList = repPost.Read().ToList();
            topic.CommentList = repComment.Read().ToList();

            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }


        // GET: Topics/Create
        public ActionResult Create()
        {
            ViewBag.StatusID = new SelectList(repTopic.Read(), "Id", "StatusID");
            ViewBag.UsersID = new SelectList(repTopic.Read(), "Id", "UserID");
           
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Subject,Created,UsersID,StatusID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                repTopic.Create(topic);

                return RedirectToAction("Index");
            }

            ViewBag.StatusID = new SelectList(repTopic.Read(), "Id", "Name", topic.StatusID);
            ViewBag.UsersID = new SelectList(repTopic.Read(), "Id", "UserName", topic.UserID);
            return View(topic);
        }

        // GET: Topics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = repTopic.Read().FirstOrDefault(x => x.ID == id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusID = new SelectList(repTopic.Read(), "Id", "Name", topic.StatusID);
            ViewBag.UsersID = new SelectList(repTopic.Read(), "Id", "UserName", topic.UserID);
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Subject,Created,UsersID,StatusID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                repTopic.Update(topic);
                return RedirectToAction("Index");
            }
            ViewBag.StatusID = new SelectList(db.Status, "Id", "Name", topic.StatusID);
            ViewBag.UsersID = new SelectList(db.Users, "Id", "UserName", topic.UserID);
            return View(topic);
        }

        // GET: Topics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = repTopic.Read().FirstOrDefault(x => x.ID == id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = repTopic.Read().FirstOrDefault(x => x.ID == id);
            repTopic.Delete(topic);
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
