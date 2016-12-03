namespace LFAForum.Repo.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        public string Context { get; set; }

        public DateTime Created { get; set; }

        public int TopicID { get; set; }

        public int UserID { get; set; }

        public int StatusID { get; set; }

        public virtual Status Status { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual User User { get; set; }
    }
}
