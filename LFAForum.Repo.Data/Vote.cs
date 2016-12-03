namespace LFAForum.Repo.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int UpCount { get; set; }

        public int DownCount { get; set; }

        public int? TopicID { get; set; }

        public int? PostID { get; set; }

        public int UserID { get; set; }

        public DateTime VotedDate { get; set; }
    }
}
