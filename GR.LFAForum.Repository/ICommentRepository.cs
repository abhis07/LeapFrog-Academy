using GR.LFAForum.Repository;
using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GR.LFAForum.Repository
{
    public interface ICommentRepository : IRepository<Comments>
    {
        
    }

    public class CommentRepository : Repository<LFAForumContext, Comments>, ICommentRepository
    {
        public CommentRepository(LFAForumContext db) : base(db)
        {

        }
        
    }
    

}
