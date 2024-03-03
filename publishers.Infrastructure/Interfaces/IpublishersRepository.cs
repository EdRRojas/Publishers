using publishers.Domain.Entities;

namespace publishers.Infrastructure.Interfaces
{
    public interface IpublishersRepository
    {
        void create(publishers publishers);
        Publishers GetPublishersByID (string publishers_Id);
        void update(publishers publishers);
        void Remote(publishers publishers);
    }
}
