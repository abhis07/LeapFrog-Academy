namespace LFAForum.Repo.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topic()
        {
            Posts = new HashSet<Post>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        public DateTime Created { get; set; }

        public int UserID { get; set; }

        public int StatusID { get; set; }

        public int? CategoryID { get; set; }

      

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        public virtual Status Status { get; set; }

        public virtual User User { get; set; }
    }
}
