using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.DataAccess.Entities.Configuration
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasMany(t => t.Comments)
                .WithOne(c => c.Task);
        }
    }
}
