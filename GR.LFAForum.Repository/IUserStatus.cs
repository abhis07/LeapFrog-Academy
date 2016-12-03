using GR.LFAForum.Repository;
using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.LFAForum.Repository
{
    public interface IUserStatusRepository : IRepository<UserStatu>
    {
        
    }

    public class UserStatusRepository : Repository<LFAForumContext, UserStatu>, IUserStatusRepository
    {
        public UserStatusRepository(LFAForumContext db) : base(db)
        {

        }

    }
    

}
