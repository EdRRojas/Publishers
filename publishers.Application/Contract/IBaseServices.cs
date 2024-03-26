

using publishers.Application.Core;
using publishers.Application.Dtos.Titles;

namespace publishers.Application.Contract
{
    public interface IBaseServices<TModel, TDtoAdd, TDtoUpdate, TDtoDelete, TData>
    {
        ServicesResult<TModel> Create(TDtoAdd DtoAdd);
        ServicesResult<TModel> Update(TDtoUpdate DtoUpdate);
        ServicesResult<TModel> Remove(TDtoDelete DtoDelete);
        ServicesResult<TModel> Get(TData id);
        ServicesResult<List<TModel>> GetAll();
    }
}
