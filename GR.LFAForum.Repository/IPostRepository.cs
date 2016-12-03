using GR.LFAForum.Repository;
using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GR.LFAForum.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        
    }

    public class PostRepository : Repository<LFAForumContext, Post>, IPostRepository
    {
        public PostRepository(LFAForumContext db) : base(db)
        {

        }

    }
    

}
