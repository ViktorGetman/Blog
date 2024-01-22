using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Blog.DAL.Entities;

namespace Blog.DAL.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {

        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(x => x.Id);
        }

    }
}
