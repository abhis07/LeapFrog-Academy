using LFAForum.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFAForum.Repo.Data
{
    public class Comments
    {
        public int ID { get; set; }


        public string Comment { get; set; }

        public int? TopicID { get; set; }

        public int? PostID { get; set; }

        public int UserID { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
