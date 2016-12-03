using GR.LFAForum.Repository;
using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GR.LFAForum.Repository
{
    public interface IGroupRepository : IRepository<Group>
    {
        
    }

    public class GroupRepository : Repository<LFAForumContext, Group>, IGroupRepository
    {
        public GroupRepository(LFAForumContext db) : base(db)
        {

        }

    }
    

}
