using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LFAForum.Models.LFAForumViewModel
{
    public class CategoryPostModel
    {
        public IEnumerable<Category> CatList { get; set; }
        public IEnumerable<Post> PostList { get; set; }
        public IEnumerable<Topic> TopicList { get; set; }
    }

    public class TopicPostViewModel
    {
        public IEnumerable<Topic> TopicList { get; set; }
        public IEnumerable<Post> PostList { get; set; }
        public IEnumerable<Comments> CommentList { get; set; }
    }
}