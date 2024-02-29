
using publishers.Domain.Entities;

namespace publishers.Infrastructure.Interfaces
{
    public interface ITitlesRepository
    {
        void Create(Titles titles);
        Titles GetTitleByID(string title_id);
        void Update(Titles titles);
        void Remote(Titles titles);

        
    }
}
