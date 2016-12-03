namespace DatabaseFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LFAForumContext : DbContext
    {
        public LFAForumContext()
            : base("name=LFAForum")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }

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
                .HasForeignKey(e => e.ParentCategoryId);

            modelBuilder.Entity<Group>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Groups)
                .Map(m => m.ToTable("UserGroup").MapLeftKey("GroupId").MapRightKey("UserId"));

            modelBuilder.Entity<Post>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Topic)
                .HasForeignKey(e => e.ThreadID)
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
                .Property(e => e.LastActivity)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Topics)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UsersId);

            modelBuilder.Entity<UserStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserStatus>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserStatu)
                .HasForeignKey(e => e.UserStatus);
        }
    }
}
