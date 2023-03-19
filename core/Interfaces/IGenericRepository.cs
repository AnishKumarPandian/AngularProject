using core.Entities;
using core.Specifications;

namespace core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

       Task<IReadOnlyList<T>> ListAllAsync();

       Task<T> GetEntityWithSpec(ISpecification<T> spec);

       Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> spec);

    }
}