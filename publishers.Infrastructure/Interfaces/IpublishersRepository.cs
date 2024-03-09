using publishers.Domain.Entities;
using publishers.Domain.Repository;
using publishers.Infrastructure.Models;

namespace publishers.Infrastructure.Interfaces
{
    public interface IpublishersRepository : IBaseRepository<Publishers, string>
    {
        publishersModel GetPubByName (string pub_name);
        List<publishersModel> GetPubByCity(string city);
        List<publishersModel> GetPubByState(string state);
        List<publishersModel> GetPubByCountry(string country);
        
    }
}
