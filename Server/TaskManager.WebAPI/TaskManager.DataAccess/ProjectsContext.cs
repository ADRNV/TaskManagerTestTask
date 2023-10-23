using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Entities.Configuration;

namespace TaskManager.DataAccess
{
    public class ProjectsContext : DbContext
    {
        public DbSet<EntityProject> Projects { get; set; }

        public DbSet<EntityTask> Tasks { get; set; }

        public DbSet<EntityComment> Comments { get; set; }

        public ProjectsContext(DbContextOptions<ProjectsContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
