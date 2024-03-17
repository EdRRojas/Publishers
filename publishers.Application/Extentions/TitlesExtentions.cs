using publishers.Application.Dtos;
using publishers.Application.Dtos.Titles;
using publishers.Application.Models.Titles;
using publishers.Domain.Entities;

namespace publishers.Application.Extentions
{
    public static class TitlesExtentions
    {
        public static TitlesModel ConvertDtoToGetEntity(this Titles titles)
        {
            return new TitlesModel()
            {
                title_id = titles.title_id,
                title = titles.title,
                type = titles.type,
                pub_id = titles.pub_id,
                price = titles.price,
                advance = titles.advance,
                royalty = titles.royalty,
                ytd_sales = titles.ytd_sales
            };
        }
        public static DtoBase ConvertDtoToGetEntity(this TitlesDtoBase titlesDtoBase)
        {
            return new TitlesDtoBase()
            {
                title_id = titlesDtoBase.title_id,
                title = titlesDtoBase.title,
                type = titlesDtoBase.type,
                pub_id = titlesDtoBase.pub_id,
                price = titlesDtoBase.price,
                advance = titlesDtoBase.advance,
                royalty = titlesDtoBase.royalty,
                ytd_sales = titlesDtoBase.ytd_sales
            };
        }
        public static Titles ConvertDtoCreateToEntity(this TitlesDtoAdd titlesDtoAdd)
        {
            Titles titles = ConvertDtoToGetEntity(titlesDtoAdd);            
            titles.creationUser = titlesDtoAdd.UserId;
            titles.creationDate = titlesDtoAdd.modifyDate;
            return titles;
        }
        public static Titles ConvertDtoUpdateToEntity(this TitlesDtoUpdate titlesDtoUpdate)
        {
            Titles titles = ConvertDtoToGetEntity(titlesDtoUpdate);            
            titles.userMod = titlesDtoUpdate.UserId;
            titles.modifyDate = titlesDtoUpdate.modifyDate;
            return titles;
        }
        public static Titles ConvertDtoDeleteToEntity(this TitlesDtoDelete titlesDtoDelete)
        {
            return new Titles()
            {
                title_id = titlesDtoDelete.title_id,
                userDelete = titlesDtoDelete.UserId,
                deleteTime = titlesDtoDelete.modifyDate,
                deleted = true
            };
        }
    }
}
