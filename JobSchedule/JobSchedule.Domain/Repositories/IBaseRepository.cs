using JobSchedule.Domain.Entities;

namespace JobSchedule.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        IQueryable<T> GetAll();
        Task<T?> FindByID(int id);
        Task Delete(T entity);
    }
}
