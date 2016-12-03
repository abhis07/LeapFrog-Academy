namespace LFAForum.Repo.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LFAForumContext : DbContext
    {
        public LFAForumContext()
            : base("name=LFAForumContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserStatu> UserStatus { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public  DbSet<Comments> Comments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Category1)
                .WithOptional(e => e.Category2)
                .HasForeignKey(e => e.ParentCategoryID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Topics)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Topics)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserStatu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserStatu>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserStatu)
                .HasForeignKey(e => e.UserStatus)
                .WillCascadeOnDelete(false);


        }
    }
}
