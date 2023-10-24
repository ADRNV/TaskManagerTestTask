using TaskManager.Core.Models;
using TaskManager.Core.Repositories;
using TaskManager.Core.Services;

namespace TaskManager.Domain
{
    public class ProjectsService : IService<Project>
    {
        private readonly IRepository<Project> _repository;

        public ProjectsService(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Create(Project entity) =>
           await _repository.Create(entity);

        public async Task<bool> Delete(Guid id) => 
            await _repository.Delete(id);
        public async Task<IEnumerable<Project>> Get(int page, int size) => 
            await _repository.Get(page, size);

        public async Task<Project> Get(Guid id) => 
           await _repository.Get(id);
        public async Task<Guid> Update(Project entity) =>
            await _repository.Update(entity);
    }
}
