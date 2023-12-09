using Blog.BLL.Models;
using Blog.DAL.Configurations;
using Blog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {
            ///Database.EnsureCreated();
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DAL/DB/BlogDB.db;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
