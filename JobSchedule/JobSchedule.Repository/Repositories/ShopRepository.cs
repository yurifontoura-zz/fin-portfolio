using JobSchedule.Domain.Entities;
using JobSchedule.Domain.Repositories;
using JobSchedule.Repository.Context;

namespace JobSchedule.Repository.Repositories
{
    public class ShopRepository : BaseRepository<Shop>, IShopRepository
    {
        public ShopRepository() : base() { }
        public ShopRepository(EFContext context) : base(context)
        {
        }
    }
}
