using GR.LFAForum.Repository;
using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GR.LFAForum.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        
    }

    public class CategoryRepository : Repository<LFAForumContext, Category>, ICategoryRepository
    {
        public CategoryRepository(LFAForumContext db) : base(db)
        {

        }
        
    }
    

}
