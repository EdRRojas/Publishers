using publishers.Domain.Entities;
using publishers.Infrastructure.Context;
using publishers.Infrastructure.Interfaces;


namespace publishers.Infrastructure.Repositories
{
    public class publishersRepository : IpublishersRepository
    {
        private readonly PubsContext context;
        public void create(Publishers publishers)
        {
            throw new NotImplementedException();
        }

        public void GetPublishersByID(String publishers_id)
        {
            throw new NotImplementedException();
        }

        public void Remote(Publishers publishers)
        {
            return this.context.publishers.Find(pub_id);
        }
    
        public void update(Publishers publishers)
        {
            throw new NotImplementedException();
        }
    }
}
