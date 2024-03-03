using publishers.Domain.Entities;

namespace publishers.Infrastructure.Interfaces
{
    public interface IpublishersRepository
    {
        void create(Publishers publishers);
        Publishers GetPublishersByID (string pub_id);
        void update(Publishers publishers);
        void Remote(Publishers publishers);
    }
}
