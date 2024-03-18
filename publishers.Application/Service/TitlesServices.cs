
using publishers.Application.Contract;
using publishers.Application.Core;
using publishers.Application.Dtos.Titles;
using publishers.Application.Extentions;
using publishers.Application.Models.Titles;
using publishers.Domain.Entities;
using publishers.Infrastructure.Interfaces;


namespace publishers.Application.Service
{
    public class TitlesServices : ITitlesServices
    {
        
        private readonly ITitlesRepository titlesRepository;        
        private readonly Exceptions.TitlesException titlesException;

        public TitlesServices(Exceptions.TitlesException titlesException, ITitlesRepository titlesRepository)
        {
            this.titlesException = titlesException;
            this.titlesRepository = titlesRepository;
        }
        public ServicesResult<TitlesModel> CreateTitle(TitlesDtoAdd titlesDtoAdd)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();
            try 
            {                         
                if (string.IsNullOrEmpty(titlesDtoAdd.title_id))
                {
                    results("El id no puede ser nulo");
                }
                if(titlesDtoAdd.title_id.Length > 6)
                {
                    results("El id no puede ser mayor de 6 caracteres");
                }
                if (string.IsNullOrEmpty(titlesDtoAdd.title))
                {
                    results("El libro debe tener un nombre");
                }
                if(titlesDtoAdd.title.Length > 80)
                {
                    results("El nombre del libro no puede tener mas de 80 caracteres");
                }
                if (string.IsNullOrEmpty(titlesDtoAdd.type))
                {
                    results("Se debe especificar un genero al libro");
                }
                if(titlesDtoAdd.type.Length > 12)
                {
                    results("El genero no puede tener mas 12 caracteres");
                }
                if(titlesDtoAdd.pub_id.Length != 4)
                {
                    results("El id del publisher debe estar registrado y debe tener justo 4 caracteres");
                }
                if(titlesDtoAdd.notes.Length > 200)
                {
                    results("La descripcion no puede tener un tamaño mayor a 200 caracteres");
                }
                if (string.IsNullOrEmpty(titlesDtoAdd.UserId.ToString()) && string.IsNullOrEmpty(titlesDtoAdd.modifyDate.ToString()))
                {
                    results("Debe especificar que usuario ha creado este registro y la fecha de creacion");
                }
                if(this.titlesRepository.Exists(ti => ti.title_id == titlesDtoAdd.title_id))
                {
                    results("Ese libro ya esta registrado");
                }

                this.titlesRepository.Create(TitlesExtentions.ConvertDtoCreateToEntity(titlesDtoAdd));
            }
            catch (Exception ex)
            {
                results("Ocurrio un error al intentar añadir el libro: ", ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> TitleRemove(TitlesDtoDelete titlesDtoDelete)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();
            try
            {
                if(this.titlesRepository.GetEntity(titlesDtoDelete.title_id).deleted == true)
                {
                    results("Este libro ya ha sido eliminado");
                }
                if (string.IsNullOrEmpty(titlesDtoDelete.UserId.ToString()) && string.IsNullOrEmpty(titlesDtoDelete.modifyDate.ToString()))
                {
                    results("Debe especificar que usuario ha elimiando este registro y la fecha de eliminacion");
                }

                this.titlesRepository.Remove(TitlesExtentions.ConvertDtoDeleteToEntity(titlesDtoDelete));
            }
            catch(Exception ex)
            {
                results("Ocurrio un error al eliminar el libro: ", ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> GetTitle(string title)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();

            try
            {
                if(this.titlesRepository.Exists(ti=> ti.title != title))
                {
                    results("Este libro no esta registrado");
                }
                var titles = this.titlesRepository.GetEntity(title);                
                result.Data = TitlesExtentions.ConvertEntityToModel(new Titles());
            }
            catch (Exception ex)
            {
                results("Ocurrio un error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitles()
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {                
                result.Data = this.titlesRepository.GetEntities().Select(ti => 
                TitlesExtentions.ConvertEntityToModel(new Titles())).ToList();

                if(result.Data == null)
                {
                    results("No hay ningun registro de la entidad Titles");
                }
            }
            catch(Exception ex) 
            {
                results("Ocurrio un error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> GetTitleByName(string name)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();

            try
            {
                if(this.titlesRepository.Exists(ti => ti.title != name))
                {
                    results("Este libro no esta registrado");
                }
                var titles = this.titlesRepository.GetTitlesByType(name);
                result.Data = TitlesExtentions.ConvertEntityToModel(new Titles());
            }
            catch(Exception ex) 
            {
                results("Error al obtener el libro: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByOnPrice(decimal price)
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {
                result.Data = this.titlesRepository.GetTitlesByOnPrice(price).Select(ti =>
                TitlesExtentions.ConvertEntityToModel(new Titles())).ToList();

                if (result.Data == null)
                {
                    results("No existen libros con ese rango de precios");
                }
            }
            catch(Exception ex)
            {
                results("Error al obtener los lirbos: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByPub(string pubId)
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {
                result.Data = this.titlesRepository.GetTitlesByPub(pubId).Select(ti =>
                TitlesExtentions.ConvertEntityToModel(new Titles())).ToList();

                if (result.Data == null)
                {
                    results("No hay libros registrados a ese publisher");
                }
            }
            catch (Exception ex)
            {
                results("Error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByType(string type)
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {
                result.Data = this.titlesRepository.GetTitlesByType(type).Select(ti =>
                TitlesExtentions.ConvertEntityToModel(new Titles())).ToList();

                if (result.Data == null)
                {
                    results("No hay libros registrados con esa categoria");
                }
            }
            catch (Exception ex)
            {
                results("Error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByUnderPrice(decimal price)
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {
                result.Data = this.titlesRepository.GetTitlesByUnderPrice(price).Select(ti =>
                TitlesExtentions.ConvertEntityToModel(new Titles())).ToList();

                if (result.Data == null)
                {
                    results("No hay libros registrados con ese rango de precios");
                }
            }
            catch (Exception ex)
            {
                results("Error al obtener los libros: ", ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> TitlesUpdate(TitlesDtoUpdate titlesDtoUpdate)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();

            try
            {   
                if(this.titlesRepository.Exists(ti => ti.title_id !=  titlesDtoUpdate.title_id))
                {
                    results("Este libro no esta registrado");
                }
                if (string.IsNullOrEmpty(titlesDtoUpdate.title))
                {
                    results("El libro debe tener un nombre");
                }
                if (titlesDtoUpdate.title.Length > 80)
                {
                    results("El nombre del libro no puede tener mas de 80 caracteres");
                }
                if (string.IsNullOrEmpty(titlesDtoUpdate.type))
                {
                    results("Se debe especificar un genero al libro");
                }
                if (titlesDtoUpdate.type.Length > 12)
                {
                    results("El genero no puede tener mas 12 caracteres");
                }               
                if (titlesDtoUpdate.notes.Length > 200)
                {
                    results("La descripcion no puede tener un tamaño mayor a 200 caracteres");
                }
                if (string.IsNullOrEmpty(titlesDtoUpdate.UserId.ToString()) && string.IsNullOrEmpty(titlesDtoUpdate.modifyDate.ToString()))
                {
                    results("Debe especificar que usuario ha modificado este registro y la fecha de modificacion");
                }

                this.titlesRepository.Update(TitlesExtentions.ConvertDtoUpdateToEntity(titlesDtoUpdate));
            }
            catch(Exception ex)
            {
                results("Error al actualizar los datos del libro", ex);
            }
            return result;
        }
        private ServicesResult<TitlesModel> results(string message)
        {
            var result = new ServicesResult<TitlesModel>();
            result.Success = false;
            result.Message = message;
            return result;
        }
        private void results (string message, Exception ex)
        {
            var result = new ServicesResult<TitlesModel>();
            result.Success = false;
            result.Message = message;
            titlesException.TitleLogError(result.Message, ex);
        }
    }
}
