using publishers.Domain.Entities;
using publishers.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace publishers.Infrastructure.Interfaces
{
    public interface IJobsRepository : IBaseRepository<Jobs, int>
    {
        Jobs GetJobByMin_lvl(int minlvl);
        Jobs GetJobByMax_lvl(int maxlvl);
    }
}
