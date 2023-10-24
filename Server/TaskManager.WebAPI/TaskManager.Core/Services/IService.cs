using TaskManager.Core.Models;
using TaskManager.Core.Repositories;

namespace TaskManager.Core.Services
{
    public interface IService<T>
    {
        Task<Guid> Create(T entity);

        Task<bool> Delete(Guid id);

        Task<Guid> Update(T entity);

        Task<IEnumerable<T>> Get(int page, int size);

        Task<T> Get(Guid id);
    }
}
