using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Repositories;

namespace TaskManager.DataAccess.Repositories
{
    public abstract class RepositoryBase<T, C> : IRepository<T> where C : ProjectsContext
    {
        protected C _context;

        protected readonly IMapper _mapper;

        public RepositoryBase(C context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }

        public abstract Task<Guid> Create(T entity);

        public abstract Task<Guid> Update(T entity);

        public abstract Task<bool> Delete(Guid id);

        public abstract Task<IEnumerable<T>> Get(int page, int pageSize);

        public abstract Task<T> Get(Guid id);

        protected virtual async Task Save<T>(T entity, EntityState entityState)
        {
            _context.Entry(entity).State = entityState;

            await _context.SaveChangesAsync();
        }

        protected D MapToEntity<D>(T entity) =>
         _mapper.Map<T, D>(entity);

        protected T MapToCore<D>(D entity) =>
            _mapper.Map<D, T>(entity);
    }
}
