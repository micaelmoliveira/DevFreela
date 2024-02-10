using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Project)
                .WithMany(c => c.Comments)
                .HasForeignKey(p => p.IdProject);

            builder
                .HasOne(p => p.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(p => p.IdUser);
        }
    }
}
