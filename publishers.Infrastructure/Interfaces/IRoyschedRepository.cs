
using publishers.Domain.Entities;
using publishers.Domain.Repository;
using publishers.Infrastructure.Models;

namespace publishers.Infrastructure.Interfaces
{
    internal interface IRoyschedRepository : IBaseRepository<roysched, string>
    {
        List<RoyschedModel> GetRoyschedByTitleName(string title);
        List<RoyschedModel> GetRoyschedByLorange(int lorange);
        List<RoyschedModel> GetRoyschedByHirange(int hirange);
        List<RoyschedModel> GetRoyschedByRoyalty(int royalty);

    }
}
