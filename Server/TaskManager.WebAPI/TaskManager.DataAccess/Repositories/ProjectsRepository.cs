using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace TaskManager.DataAccess.Repositories
{
    public class ProjectsRepository : RepositoryBase<CoreProject, ProjectsContext>
    {
        public ProjectsRepository(ProjectsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<Guid> Create(CoreProject entity)
        {
            var dbEntity = MapToEntity<EntityProject>(entity);

            await _context.Projects.AddAsync(dbEntity);

            await Save(dbEntity, EntityState.Added);

            return dbEntity.Id;
        }

        public override async Task<bool> Delete(Guid id)
        {
            var dbEntity = await _context.Projects.FindAsync(new object[] { id});

            var entityFound = dbEntity is not null;
            
            if (entityFound)
            {
                _context.Projects.Remove(dbEntity);

            }

            return entityFound;
        }

        public override Task<IEnumerable<CoreProject>> Get(int page, int size)
        {
            var projects = _context.Projects
               .AsNoTracking()
               .Include(p => p.Tasks)
               .Skip((page - 1) * size)
               .Take(size)
               .AsEnumerable();

            return Task.FromResult(_mapper.Map<IEnumerable<CoreProject>>(projects));
        }

        public override async Task<CoreProject> Get(Guid id)
        {
            var dbEntity = await _context.Projects
                .AsNoTracking()
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id);

            return MapToCore(dbEntity);
        }

        public override async Task<Guid> Update(CoreProject entity)
        {
            var dbEntity = await _context.Projects.FindAsync(new object[]{ entity.Id});

            dbEntity = MapToEntity<EntityProject>(entity);

            await Save(dbEntity, EntityState.Modified);

            return dbEntity.Id;
        }
    }
}
