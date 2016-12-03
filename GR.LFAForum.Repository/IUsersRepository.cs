using GR.LFAForum.Repository;
using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GR.LFAForum.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        
    }

    public class UserRepository : Repository<LFAForumContext, User>, IUserRepository
    {
        public UserRepository(LFAForumContext db) : base(db)
        {

        }

    }
    

}
