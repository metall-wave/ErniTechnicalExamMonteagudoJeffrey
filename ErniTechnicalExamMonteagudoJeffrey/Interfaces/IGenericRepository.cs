using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ErniTechnicalExamMonteagudoJeffrey.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<EntityEntry<T>> AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
