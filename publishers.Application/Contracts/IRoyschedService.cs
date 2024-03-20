using publishers.Application.Core;
using publishers.Application.DTO.Roysched;
using publishers.Application.Models;

namespace publishers.Application.Contracts
{
    public interface IRoyschedService
    {
        ServiceResult <List<RoyschedGetModel>> GetRoyscheds();
        ServiceResult<RoyschedGetModel> GetRoyschedById(string id);
        ServiceResult<string> AddRoysched(RoyschedAddDto royschedAddDto);
        ServiceResult<bool> UpdateRoyshed(RoyschedUpdateDto royschedUpdateDto); 
        ServiceResult<bool> RemoveRoysched(string id);
    }
}
