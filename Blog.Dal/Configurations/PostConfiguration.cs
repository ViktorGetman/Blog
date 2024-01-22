using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Blog.DAL.Entities;

namespace Blog.DAL.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {

        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.Id);
        }

    }
}
