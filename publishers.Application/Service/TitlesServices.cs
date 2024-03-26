
using Microsoft.Extensions.Logging;
using publishers.Application.Contract;
using publishers.Application.Core;
using publishers.Application.Dtos.Enums;
using publishers.Application.Dtos.Titles;
using publishers.Application.Extentions;
using publishers.Application.Models.Enums;
using publishers.Application.Models.Titles;
using publishers.Infrastructure.Interfaces;





namespace publishers.Application.Service
{
    public class TitlesServices : ITitlesServices
    {
        private readonly ITitlesRepository titlesRepository;
        private readonly ILogger<TitlesServices> logger;

        public TitlesServices(ITitlesRepository titlesRepository, ILogger<TitlesServices> logger)
        {
            this.titlesRepository = titlesRepository;
            this.logger = logger;
        }
        public ServicesResult<TitlesModel> Create(TitlesDtoAdd titlesDtoAdd)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();
            try 
            {
                var resultIsValid = this.IsValidDto(titlesDtoAdd, DtoAction.Create);

                if (titlesDtoAdd.pub_id.Length != 4)
                {
                    result.Success = false;
                    result.Message = "El id del publisher debe estar registrado y debe tener justo 4 caracteres";

                    return result;
                }

                if (!resultIsValid.Success)
                {
                    result.Success = resultIsValid.Success;
                    result.Message = resultIsValid.Message;
                    return result;
                }

                this.titlesRepository.Create(TitlesExtentions.ConvertDtoCreateToEntity(titlesDtoAdd));
            }
            catch (Exception ex)
            {
                results(result, "Ocurrio un error al intentar añadir el libro: ", ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> Update(TitlesDtoUpdate titlesDtoUpdate)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();

            try
            {
                var resultIsValid = this.IsValidDto(titlesDtoUpdate, DtoAction.Update);

                if (!resultIsValid.Success)
                {
                    result.Success = resultIsValid.Success;
                    result.Message = resultIsValid.Message;
                    return result;
                }

                this.titlesRepository.Update(TitlesExtentions.ConvertDtoUpdateToEntity(titlesDtoUpdate));
                
            }
            catch (Exception ex)
            {
                results(result, "Error al actualizar los datos del libro", ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> Remove(TitlesDtoDelete titlesDtoDelete)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();
            try
            {
                if(this.titlesRepository.GetEntity(titlesDtoDelete.title_id).deleted == true)
                {
                    result.Success = false;
                    result.Message = "El libro ya esta elliminado";
                    return result;
                }                

                this.titlesRepository.Remove(TitlesExtentions.ConvertDtoDeleteToEntity(titlesDtoDelete));
            }
            catch(Exception ex)
            {
                results(result, "Ocurrio un error al eliminar el libro: ", ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> Get(string title_id)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();

            try
            {
                var titles = this.titlesRepository.GetEntity(title_id);

                var resultIsValid = this.IsValidModel(result, ModelAction.Get, title_id);

                if (!resultIsValid.Success)
                {
                    result.Success = resultIsValid.Success;
                    result.Message = resultIsValid.Message;

                    return result;
                }

                result.Data = TitlesExtentions.ConvertEntityToModel(titles);

                
            }
            catch (Exception ex)
            {
                results(result, "Ocurrio un error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetAll()
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {                
                result.Data = this.titlesRepository.GetEntities().Select(ti => TitlesExtentions.ConvertEntityToModel(ti)).ToList();

                var resultIsValid = this.IsValidModel(result, ModelAction.TitleList);

                if (!resultIsValid.Success)
                {
                    result = resultss(resultIsValid, resultIsValid.Message);
                    return result;
                }                
            }
            catch(Exception ex) 
            {
                results(result, "Ocurrio un error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> GetTitleByName(string name)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();

            try
            {   
                              
                var titles = this.titlesRepository.GetTitleByName(name);

                var resultIsValid = this.IsValidModel(result, ModelAction.TitleByName, name);

                if (!resultIsValid.Success)
                {
                    result.Success = resultIsValid.Success;
                    result.Message = resultIsValid.Message;

                    return result;
                }

                result.Data = TitlesExtentions.ConvertModelToModel(titles);
            }
            catch(Exception ex) 
            {
                results(result, "Error al obtener el libro: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByOnPrice(decimal price)
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {
                result.Data = this.titlesRepository.GetTitlesByOnPrice(price).Select(ti => TitlesExtentions.ConvertModelToModel(ti)).ToList();

                var resultIsValid = this.IsValidModel(result, ModelAction.TitleList);

                if (!resultIsValid.Success)
                {
                    result = resultss(resultIsValid, resultIsValid.Message);
                    return result;
                }
            }
            catch(Exception ex)
            {
                results(result,"Error al obtener los lirbos: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByPub(string pubId)
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {
                result.Data = this.titlesRepository.GetTitlesByPub(pubId).Select(ti =>
                TitlesExtentions.ConvertModelToModel(ti)).ToList();

                var resultIsValid = this.IsValidModel(result, ModelAction.TitleList);

                if (!resultIsValid.Success)
                {
                    result = resultss(resultIsValid, resultIsValid.Message);
                    return result;
                }
            }
            catch (Exception ex)
            {
                results(result, "Error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByType(string type)
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {
                result.Data = this.titlesRepository.GetTitlesByType(type).Select(ti =>
                TitlesExtentions.ConvertModelToModel(ti)).ToList();
                var resultIsValid = this.IsValidModel(result, ModelAction.TitleList);

                if (!resultIsValid.Success)
                {
                    result = resultss(resultIsValid, resultIsValid.Message);
                    return result;
                }
            }
            catch (Exception ex)
            {
                results(result, "Error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByUnderPrice(decimal price)
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {
                result.Data = this.titlesRepository.GetTitlesByUnderPrice(price).Select(ti =>
                TitlesExtentions.ConvertModelToModel(ti)).ToList();

                var resultIsValid = this.IsValidModel(result, ModelAction.TitleList);

                if (!resultIsValid.Success)
                {
                    result = resultss(resultIsValid, resultIsValid.Message);
                    return result;
                }
            }
            catch (Exception ex)
            {
                results(result, "Error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> GetTitleSalesByID(string id)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();
            try
            {               
                var titles = this.titlesRepository.GetTitleSalesByID(id);

                if (titles != null)
                {
                    result.Data = new TitlesModel()
                    {
                        ytd_sales = titles.ytd_sales
                    };
                }

                var resultIsValid = this.IsValidModel(result, ModelAction.TitleSalesByID, id);

                if (!resultIsValid.Success)
                {
                    result.Success = resultIsValid.Success;
                    result.Message = resultIsValid.Message;

                    return result;
                }
            }
            catch(Exception ex)
            {
                results(result, "Ocurrio un error al buscar el libro: ", ex);
            }

            return result;
            
        }        
        private ServicesResult<string> IsValidDto (TitlesDtoBase titlesDtoBase, DtoAction action)
        {
            ServicesResult<string> result = new ServicesResult<string>();

            if (action == DtoAction.Create | action == DtoAction.Update)
            {
                if (string.IsNullOrEmpty(titlesDtoBase.title_id))
                {
                    result = results(result, "El id no puede ser nulo");
                    return result;
                }
                if (string.IsNullOrEmpty(titlesDtoBase.title))
                {
                    result = results(result, "El libro debe tener un nombre");
                    return result;
                }
                if (titlesDtoBase.title.Length > 80)
                {
                    result = results(result, "El nombre del libro no puede tener mas de 80 caracteres");
                    return result;
                }
                if (string.IsNullOrEmpty(titlesDtoBase.type))
                {
                    result = results(result, "Se debe especificar un genero al libro");
                    return result;
                }
                if (titlesDtoBase.type.Length > 12)
                {
                    result = results(result, "El genero no puede tener mas 12 caracteres");
                    return result;
                }
                if (titlesDtoBase.notes.Length > 200)
                {
                    result = results(result, "La descripcion no puede tener un tamaño mayor a 200 caracteres");
                    return result;
                }
            }            

            if (string.IsNullOrEmpty(titlesDtoBase.UserId.ToString()))
            {
                result = results(result, "Debe especificar que usuario ha modificado este registro");
                return result;
            }
            if (string.IsNullOrEmpty(titlesDtoBase.modifyDate.ToString()))
            {
                result = results(result, "Debe especificar la fecha de modificacion");
                return result;
            }

            if(action == DtoAction.Create)
            {
                if (this.titlesRepository.Exists(ti => ti.title_id == titlesDtoBase.title_id))
                {
                    result = results(result, "Ese libro ya esta registrado");
                    return result;
                }
                if (titlesDtoBase.title_id.Length > 6)
                {
                    result = results(result, "El id no puede ser mayor de 6 caracteres");
                    return result;
                }

            }

            if (action == DtoAction.Update)
            {
                var entity = this.titlesRepository.GetEntity(titlesDtoBase.title_id);

                if (entity != null && entity.deleted)
                {
                    result = results(result, "Este libro está eliminado.");
                    return result;
                }
                
                if (!this.titlesRepository.Exists(ti => ti.title_id == titlesDtoBase.title_id))
                {
                    result = results(result, "El libro especificado no esta registrado");
                    return result;
                } 
            }            

            return result;
        }
        private ServicesResult<string> IsValidModel(ServicesResult<List<TitlesModel>> titlesModel, ModelAction action)
        {
            ServicesResult<string> result = new ServicesResult<string>();

            if (action == ModelAction.TitleList)
            {
                if (titlesModel.Data == null)
                {
                    result = results(result, "No se ha encontrado ningun registro");
                    return result;
                }
            }
            
            return result;
            
        }
        private ServicesResult<string> IsValidModel(ServicesResult<TitlesModel> titlesModel, ModelAction action, string id)
        {
            ServicesResult<string> result = new ServicesResult<string>(); 
            
            if(action == ModelAction.Get || action == ModelAction.TitleSalesByID)
            {
                if (!this.titlesRepository.Exists(ti => ti.title_id == id))
                {
                    result = results(result, "El libro especificado no esta registrado");
                    return result;
                }
                if (action == ModelAction.TitleSalesByID)
                {
                    if (titlesModel.Data != null && titlesModel.Data.ytd_sales == null)
                    {
                        result = results(result, "Este libro no tiene ventas registradas");
                        return result;
                    }
                }
            }
            if(action == ModelAction.TitleSalesByID)
            {
                if (titlesModel.Data != null && titlesModel.Data.ytd_sales == null)
                {
                    result = results(result, "Este libro no tiene ventas registradas");
                    return result;
                }
            }
            if(action == ModelAction.TitleByName)
            {
                if (!this.titlesRepository.Exists(ti => ti.title == id))
                {
                    result = results(result, "Este libro no esta registrado");
                    return result;
                }
            }

            return result;
        }

        private ServicesResult<string> results(ServicesResult<string> result, string message)
        {
            result.Success = false;
            result.Message = message;

            return result;
        }
        private ServicesResult<List<TitlesModel>> resultss(ServicesResult<string> resultIsValid, string message)
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            result.Success = resultIsValid.Success;
            result.Message = resultIsValid.Message;

            return result;
        }
        private void results(ServicesResult<TitlesModel> result, string message, Exception ex)
        {
            result.Success = false;
            result.Message = message;
            var titlesException = new Exceptions.TitlesException(message, ex, logger);
            titlesException.TitleLogError(message, ex);
        }
        private void results(ServicesResult<List<TitlesModel>> result, string message, Exception ex)
        {
            result.Success = false;
            result.Message = message;
            var titlesException = new Exceptions.TitlesException(message, ex, logger);
            titlesException.TitleLogError(message, ex);
        }        
    }
}
