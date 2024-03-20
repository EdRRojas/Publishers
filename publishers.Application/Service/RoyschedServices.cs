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
                repository.Create(new Domain.Entities.roysched
                {
                    title_id = royschedAddDto.title_id,
                    hirange = royschedAddDto.hirange,
                    lorange = royschedAddDto.lorange,
                    royalty = royschedAddDto.royalty,
                    CreationDate = DateTime.Today,
                    CreationUser = royschedAddDto.CreationUser
                });
                
                result.Message = "El Roysched fue agregado correctamente";
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = "Error obteniendo los Royscheds";
                this.logger.LogError(result.Message, ex);
            }

            return result;
            
        }

        public ServiceResult<bool> DeleteRoysched(RoyschedReomveDto royschedReomveDto)
        {
           ServiceResult<bool> result = new ServiceResult<bool>();
            try
            {
                this.repository.Remove(new Domain.Entities.roysched()
                {
                    title_id = royschedReomveDto.title_id,
                    royalty = royschedReomveDto.royalty,
                    hirange = royschedReomveDto.hirange,
                    lorange = royschedReomveDto.lorange,
                    UserDeleted = royschedReomveDto.userDelete,
                    DeleteTime = royschedReomveDto.deleteTime,
                    Deleted = royschedReomveDto.deleted
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los Royscheds";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }

        public ServiceResult<RoyschedGetModel> GetRoyschedById(string id)
        {
            ServiceResult<RoyschedGetModel> result = new ServiceResult<RoyschedGetModel>();
            try
            {
                var roysched = this.repository.GetEntityById(id);
                RoyschedGetModel royschedGetModel = new RoyschedGetModel()
                {
                    title_id = roysched.title_id,
                    lorange = roysched.lorange,
                    hirange = roysched.hirange,
                    royalty = roysched.royalty,
                    CreationDate = roysched.CreationDate,
                    CreationUser = roysched.CreationUser,
                };
                result.Data = royschedGetModel;


            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = "Error obteniendo los Royscheds";
                this.logger.LogError(result.Message, ex);
            }
            return result;
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
            ServiceResult<bool> result = new ServiceResult<bool>();

            try
            {
                repository.Update(new Domain.Entities.roysched()
                {
                    title_id = royschedUpdateDto.title_id,
                    royalty = royschedUpdateDto.royalty,
                    hirange = royschedUpdateDto.hirange,
                    lorange = royschedUpdateDto.lorange,
                    UserMod = royschedUpdateDto.userMod,
                    ModifyDate = DateTime.Today

                }) ;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error actualizando el campo";
                this.logger.LogError(result.Message, ex);

            }


            return result;
        }
    }
}
