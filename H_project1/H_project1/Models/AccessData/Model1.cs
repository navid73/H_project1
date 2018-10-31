namespace H_project1.Models.AccessData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<friends> friends { get; set; }
        public virtual DbSet<Hoby> Hobies { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Page_index> Page_index { get; set; }
        public virtual DbSet<page_login> page_login { get; set; }
        public virtual DbSet<Post_Comment> Post_Comment { get; set; }
        public virtual DbSet<Post_Like> Post_Like { get; set; }
        public virtual DbSet<REportUser> REportUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersPost> UsersPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
