using publishers.Application.Core;

namespace publishers.Web.Services.Core
{
    public interface IBaseServices<TResults, TDatail, TData, TDtoAdd, TDtoUpdate>
    {
        Task<TResults> GetAll();
        Task<TDatail> Get(TData id);
        Task<ServicesResult<TDtoAdd>> Create(TDtoAdd dtoAdd);
        Task<ServicesResult<TDtoUpdate>> Update(TDtoUpdate dtoUpdate);
    }
}
