using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.DataAccess.Entities.Configuration
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasMany(p => p.Tasks)
                .WithOne(p => p.Project);
        }
    }
}
