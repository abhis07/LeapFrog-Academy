using GR.LFAForum.Repository;
using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GR.LFAForum.Repository
{
    public interface IStatusRepository : IRepository<Status>
    {
        
    }

    public class StatusRepository : Repository<LFAForumContext, Status>, IStatusRepository
    {
        public StatusRepository(LFAForumContext db) : base(db)
        {

        }

    }
    

}
