using Microsoft.Extensions.Logging;
using publishers.Application.Contracts;
using publishers.Application.Core;
using publishers.Application.DTO.Roysched;
using publishers.Application.Models;
using publishers.Infrastructure.Interfaces;
using publishers.Infrastructure.Models;
using publishers.Infrastructure.Repositories;
using System.Collections.Immutable;

namespace publishers.Application.Service
{
    public class RoyschedServices : IRoyschedService
    {
        
        ILogger<RoyschedServices> logger;
        IRoyschedRepository repository;

        public RoyschedServices(ILogger<RoyschedServices> logger, IRoyschedRepository royschedRepository)
        {
            this.logger = logger;
            repository = royschedRepository;
        }
        public ServiceResult<string> AddRoysched(RoyschedAddDto royschedAddDto)
        {
            ServiceResult <string> result = new ServiceResult<string>();
            try
            {
                
                result.Message = "El Roysched fue agregado correctamente";
            }
            catch 
            {
                result.Message = "El Roysched no pudo ser agregado";
            }

            return result;
            
        }

        public ServiceResult<bool> DeleteRoysched(RoyschedReomveDto royschedReomveDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<RoyschedGetModel> GetRoyschedById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<List<RoyschedGetModel>> GetRoyscheds()
        {
            ServiceResult<List<RoyschedGetModel>> result = new ServiceResult<List<RoyschedGetModel>>();

            try
            {
                result.Data = this.repository.GetEntities().Select(CD => new RoyschedGetModel { 
                
                    title_id = CD.title_id,
                    CreationUser = CD.CreationUser,
                    CreationDate = CD.CreationDate,
                    hirange = CD.hirange,
                    royalty = CD.royalty,
                    lorange = CD.lorange


                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los Royscheds";
                this.logger.LogError(result.Message,ex);
            }

            return result;
        }

        public ServiceResult<bool> UpdateRoyshed(RoyschedUpdateDto royschedUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
