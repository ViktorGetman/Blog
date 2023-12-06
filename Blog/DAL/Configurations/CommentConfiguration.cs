using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Blog.DAL.Entities;

namespace Blog.DAL.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
    {

        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.Id);
        }

    }

}
