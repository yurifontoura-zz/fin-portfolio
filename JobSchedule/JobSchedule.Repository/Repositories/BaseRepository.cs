using JobSchedule.Domain.Entities;
using JobSchedule.Domain.Repositories;
using JobSchedule.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace JobSchedule.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly EFContext _context;

        public BaseRepository() { }
        public BaseRepository(EFContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            var insertedEntity = await _context.AddAsync(entity);

            return insertedEntity.Entity;
        }

        public Task Delete(T entity)
        {
            return Task.Run(() => _context.Remove(entity));
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public Task<T?> FindByID(int id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(e => e.ID == id);
        }

        public Task Update(T entity)
        {
            return Task.Run(() => _context.Update(entity));
        }
    }
}
