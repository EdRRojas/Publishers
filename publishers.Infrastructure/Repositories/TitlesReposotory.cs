

using publishers.Domain.Entities;
using publishers.Infrastructure.Context;
using publishers.Infrastructure.Interfaces;

namespace publishers.Infrastructure.Repositories
{
    public class TitlesReposotory : ITitlesRepository
    {
        private readonly PubsContext context;

        public TitlesReposotory(PubsContext context) {
            this.context = context;
        }
        public void Create(Titles titles)
        {
            try
            {
                this.context.titles.Add(titles);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Titles GetTitleByID(string title_id)
        {
            return this.context.titles.Find(title_id);
        }

        public void Remote(Titles titles)
        {
            try
            {
                var TitlesToDelete = this.GetTitleByID(titles.title_id);

                TitlesToDelete.deleted = true;
                TitlesToDelete.userDeleted = titles.userDeleted;
                TitlesToDelete.deletedDate = titles.deletedDate;

                this.context.titles.Update(TitlesToDelete);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Titles titles)
        {
            try
            {
                var TitlesToUpdate = this.GetTitleByID(titles.title_id);

                TitlesToUpdate.title = titles.title;
                TitlesToUpdate.type = titles.type;
                TitlesToUpdate.price = titles.price;
                TitlesToUpdate.advance = titles.advance;
                TitlesToUpdate.royalty = titles.royalty;
                TitlesToUpdate.ytd_sales = titles.ytd_sales;
                TitlesToUpdate.notes = titles.notes;
                TitlesToUpdate.pubdate = titles.pubdate;
                TitlesToUpdate.userMod = titles.userMod;
                TitlesToUpdate.modifyDate = titles.modifyDate;

                this.context.titles.Update(TitlesToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex){
                throw ex;
            }
        }
    }
}
