namespace DatabaseFirst
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

        public int TopicId { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        public DateTime? Created { get; set; }

        public int? UsersId { get; set; }

        public int? StatusId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        public virtual Status Status { get; set; }

        public virtual User User { get; set; }
    }
}
