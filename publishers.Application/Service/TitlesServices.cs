using Microsoft.EntityFrameworkCore.Metadata.Internal;
using publishers.Application.Contract;
using publishers.Application.Core;
using publishers.Application.Dtos.Titles;
using publishers.Application.Extentions;
using publishers.Application.Models.Titles;
using publishers.Domain.Entities;
using publishers.Infrastructure.Extentions;
using publishers.Infrastructure.Interfaces;


namespace publishers.Application.Service
{
    public class TitlesServices : ITitlesServices
    {
        
        private readonly ITitlesRepository titlesRepository;        
        private readonly publishers.Application.Exceptions.TitlesException titlesException;

        public TitlesServices(Exceptions.TitlesException titlesException, ITitlesRepository titlesRepository)
        {
            this.titlesException = titlesException;
            this.titlesRepository = titlesRepository;
        }
        public ServicesResult<TitlesModel> CreateTitle(TitlesDtoAdd titlesDtoAdd)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<TitlesModel> DeleteTitle(TitlesDtoDelete titlesDtoDelete)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<TitlesModel> GetTitle(string title)
        {
            ServicesResult<TitlesModel> result = new ServicesResult<TitlesModel>();
            try
            {
                var titles = this.titlesRepository.GetEntity(title);                
                result.Data = TitlesExtentions.ConvertDtoToGetEntity(new Titles());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error al obtener el libro: ";
                titlesException.TitleLogError(result.Message, ex);
            }
            return result;
        }

        public ServicesResult<List<TitlesModel>> GetTitles()
        {
            ServicesResult<List<TitlesModel>> result = new ServicesResult<List<TitlesModel>>();

            try
            {
                result.Data = this.titlesRepository.GetEntities().Select(ti => 
                TitlesExtentions.ConvertDtoToGetEntity(new Titles())).ToList();
            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = "Ocurrio un error al buscar los libros";
                titlesException.TitleLogError(result.Message, ex);
            }
            return result;
        }

        public ServicesResult<TitlesModel> GetTitlesByName(string name)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByOnPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByPub(string pubId)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByType(string type)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<List<TitlesModel>> GetTitlesByUnderPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public ServicesResult<TitlesModel> UpdateTitle(TitlesDtoUpdate titlesDtoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
