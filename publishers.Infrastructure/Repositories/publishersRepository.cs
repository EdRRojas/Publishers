using publishers.Domain.Entities;
using publishers.Infrastructure.Context;
using publishers.Infrastructure.Interfaces;


namespace publishers.Infrastructure.Repositories
{
    public class publishersRepository : IpublishersRepository
    {
        private readonly PubsContext context;
        public publishersRepository(PubsContext context)
        {
            this.context = context;
        }
        public void create(Publishers publishers)
        {
            try
            {
                this.context.publishers.Add(publishers);
                this.context.SaveChanges();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public Publishers GetPublishersByID(string pub_id)
        {
            return this.context.publishers.Find(pub_id);
        }

        public void Remote(Publishers publishers)
        {
            try
            {
                var PublishersToDelete = this.GetPublishersByID(publishers.pub_id);

                PublishersToDelete.deleted = true;
                PublishersToDelete.userDeleted = publishers.userDeleted;
                PublishersToDelete.deleteTime = publishers.deleteTime;

                this.context.publishers.Update(PublishersToDelete);
                this.context.SaveChanges();
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public void update(Publishers publishers)
        {
            try
            {

                var PublishersToUpdate = this.GetPublishersByID(publishers.pub_id);

                PublishersToUpdate.pub_name = publishers.pub_name;
                PublishersToUpdate.city = publishers.city;
                PublishersToUpdate.state = publishers.state;
                PublishersToUpdate.country = publishers.country;
                PublishersToUpdate.userMod = publishers.userMod;
                PublishersToUpdate.modifyDate = publishers.modifyDate;

                this.context.publishers.Update(PublishersToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex){
                throw ex;
            }
        }
    }
}
