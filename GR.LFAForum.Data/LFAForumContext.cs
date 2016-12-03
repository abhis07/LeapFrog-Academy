//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GR.LFAForum.Data
//{
//    public class LFAForumContext : DbContext
//    {
//        public LFAForumContext() : base("LFAForum")
//        {

//        }
//        public DbSet<Category> Categories { get; set; }
//        public DbSet<Groups> Groups { get; set; }
//        public DbSet<UserGroup> UserGroup { get; set; }
//        public DbSet<Users> Users { get; set; }
//        public DbSet<Topic> Topic { get; set; }
//        public DbSet<Post> Post { get; set; }
//        public DbSet<UserStatus> UserStatus { get; set; }
//        public DbSet<Status> Status { get; set; }

//    }
//    public class Category
//    {
//        [Key]
//        public int CategoryId { get; set; }

//        [Required]
//        [StringLength(100)]
//        [Display(Name = "Category Name")]
//        public string CategoryName { get; set; }

//        [Required]
//        public string Description { get; set; }

//        [Required]
//        public int Creator { get; set; }

//        [Required]
//        [ForeignKey("Status")]
//        public int StatusId { get; set; }
//        public virtual Status Status { get; set; }

//    }

//    public class Groups
//    {
//        [Key]
//        public int GroupId { get; set; }

//        [StringLength(100)]
//        public string Name { get; set; }

//        [Required]
//        [ForeignKey("Category")]
//        public int CategoryId { get; set; }
//        public virtual Category Category { get; set; }

//        [Required]

//        public int CreatorId { get; set; }
//        public virtual Users Users { get; set; }
//    }

//    public class UserGroup
//    {
//        [Key, Column(Order = 0)]

//        public int UserId { get; set; }
//        public virtual Users Users { get; set; }

//        [Key, Column(Order = 1)]

//        public int GroupId { get; set; }
//        public virtual Groups Groups { get; set; }
//    }

//    public class Topic
//    {
//        [Key]
//        public int TopicId { get; set; }

//        [Required]
//        [StringLength(200)]
//        public string Subject { get; set; }

//        [Required]
//        public DateTime Created { get; set; }

//        [Required]
//        [ForeignKey("Users")]
//        public int UsersId { get; set; }
//        public virtual Users Users { get; set; }

//        [Required]
//        [ForeignKey("Status")]
//        public int StatusId { get; set; }
//        public virtual Status Status { get; set; }
//    }

//    public class UserStatus
//    {
//        public int UserStatusId { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string UserStatusName { get; set; }
//    }

//    public class Users
//    {
//        [Key]
//        public int UserId { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string UserName { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string FirstName { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string LastName { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string Email { get; set; }

//        [Required]
//        public DateTime Created { get; set; }

//        public DateTime LastActivity { get; set; }

//        [Required]
//        public bool IsModerator { get; set; }

//        [Required]
//        [ForeignKey("UserStatus")]
//        public int UserStatusId { get; set; }
//        public virtual UserStatus UserStatus { get; set; }

//    }

//    public class Post
//    {
//        public int PostId { get; set; }

//        [Required]
//        [StringLength(200)]
//        public string Subject { get; set; }


//        public string Context { get; set; }

//        [Required]
//        public DateTime Created { get; set; }

//        [ForeignKey("Topic")]
//        public int TopicId { get; set; }
//        public virtual Topic Topic { get; set; }

//        [Required]
//        [ForeignKey("Users")]
//        public int UsersId { get; set; }
//        public virtual Users Users { get; set; }

//        [Required]
//        [ForeignKey("Status")]
//        public int StatusId { get; set; }
//        public virtual Status Status { get; set; }
//    }

//    public class Status
//    {
//        public int StatusId { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string Name { get; set; }
//    }
//}


