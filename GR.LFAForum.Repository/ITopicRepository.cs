using GR.LFAForum.Repository;
using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GR.LFAForum.Repository
{
    public interface ITopicRepository : IRepository<Topic>
    {
        
    }

    public class TopicRepository : Repository<LFAForumContext, Topic>, ITopicRepository
    {
        public TopicRepository(LFAForumContext db) : base(db)
        {

        }

    }
    

}
