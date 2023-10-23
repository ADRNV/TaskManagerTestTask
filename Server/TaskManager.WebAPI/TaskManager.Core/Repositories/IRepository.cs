namespace TaskManager.Core.Repositories
{
    public interface IRepository<T>
    {
        Task<Guid> Create(T entity);

        Task<Guid> Update(T entity);

        Task<bool> Delete(Guid id);

        Task<IEnumerable<T>> Get(int page, int pageSize);

        Task<T> Get(Guid id);
    }
}
