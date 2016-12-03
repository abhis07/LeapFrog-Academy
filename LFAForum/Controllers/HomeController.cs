using GR.LFAForum.Repository;
using LFAForum.Models;
using LFAForum.Models.LFAForumViewModel;
using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LFAForum.Controllers
{
    
    public class HomeController : Controller
    {
        private LFAForumContext db = new LFAForumContext();
        private CategoryRepository repCategory;
        private PostRepository repPost;
        private TopicRepository repTopic;


        public HomeController()
        {
            repCategory = new CategoryRepository(db);                           // ur = new UserRepository(db);
            repPost = new PostRepository(db);
            repTopic = new TopicRepository(db);

        }
        public ActionResult Index()
        {
            //ViewBag.CatNames = TempData["GetCatNames"];
            ////ViewBag.CatNames = "apple";
            var m = new CategoryPostModel();

            m.CatList = repCategory.Read().ToList();
            m.PostList = repPost.Read().ToList();
            m.TopicList = repTopic.Read().ToList();
            // Top = repTopic.Read().ToList();


            return View(m);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}