using Blog.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.Configurations
{
    
        public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
        {

            public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
            {
                builder.ToTable("UsersRole");

                builder.HasKey(x => x.Id);
            }

        }
    
}
