using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Repositories;

namespace TaskManager.DataAccess.Repositories
{
    public abstract class RepositoryBase<T, C> : IRepository<T> where C: ProjectsContext
    {
        protected C _usersContext;

        protected readonly IMapper _mapper;

        public RepositoryBase(C usersContext, IMapper mapper)
        {
            _usersContext = usersContext;

            _mapper = mapper;
        }

        public abstract Task<Guid> Create(T entity);
        
        public abstract Task<Guid> Update(T entity);

        public abstract Task<bool> Delete(Guid id);

        public abstract Task<IEnumerable<T>> Get(int page, int pageSize);

        public abstract Task<T> Get(Guid id);

        protected virtual async Task Save<T>(T entity, EntityState entityState)
        {
            _usersContext.Entry(entity).State = entityState;

            await _usersContext.SaveChangesAsync();
        }

        protected D MapToEntity<D>(T invation) =>
         _mapper.Map<T, D>(invation);

        protected T MapToCore<D>(D invation) =>
            _mapper.Map<D, T>(invation);
    }
}
