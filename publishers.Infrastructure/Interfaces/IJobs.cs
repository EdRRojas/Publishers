using publishers.Domain.Entities;

namespace publishers.Infrastructure.Interfaces
{
    internal interface IJobs
    {
        void Update(Jobs jobs);
        void Remove(Jobs jobs);
        void Create(Jobs jobs);
        Jobs GetJobById(int job_id);
    }
}
