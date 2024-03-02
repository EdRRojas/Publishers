using publishers.Domain.Entities;
using publishers.Domain.Repository;
using publishers.Infrastructure.Models;


namespace publishers.Infrastructure.Interfaces
{
    internal interface IStoreRepository: IBaseRepository<Store, string>
    {
        List<Store> GetStoresByState(string state);
        Store GetStoreById(string stor_id);
    }
}