using publishers.Application.Core;
using publishers.Application.Models;

namespace publishers.Application.Contracts
{
    public interface IRoyschedService
    {
      public ServiceResult <List<RoyschedGetModel>> GetEntities();
    }
}
