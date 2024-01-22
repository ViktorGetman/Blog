using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Blog.DAL.Entities;

namespace Blog.DAL.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<TagEntity>
    {

        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.ToTable("Tags");

            builder.HasKey(x => x.Id);
        }

    }
}
