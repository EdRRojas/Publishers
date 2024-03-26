using publishers.Application.Dtos.Titles;
using publishers.Domain.Entities;

namespace publishers.Application.Extentions
{
    public static class TitlesExtentions
    {
        public static Models.Titles.TitlesModel ConvertEntityToModel(Titles titles)
        {
            return new Models.Titles.TitlesModel
            {
                title_id = titles.title_id,
                title = titles.title,
                type = titles.type,
                pub_id = titles.pub_id,
                price = titles.price,
                advance = titles.advance,
                royalty = titles.royalty,
                ytd_sales = titles.ytd_sales,
                notes = titles.notes,
                pubdate = titles.pubdate
            };
        }

        public static Models.Titles.TitlesModel ConvertModelToModel(Infrastructure.Models.TitlesModel titlesModel)
        {
            return new Models.Titles.TitlesModel
            {
                title_id = titlesModel.title_id,
                title = titlesModel.title,
                type = titlesModel.type,
                pub_id = titlesModel.pub_id,
                price = titlesModel.price,
                advance = titlesModel.advance,
                royalty = titlesModel.royalty,
                ytd_sales = titlesModel.ytd_sales,
                notes = titlesModel.notes,
                pubdate = titlesModel.pubdate
            };
        }

        public static Titles ConvertDtoToGetEntity(TitlesDtoBase titlesDtoBase)
        {
            return new Titles()
            {
                title_id = titlesDtoBase.title_id,
                title = titlesDtoBase.title,
                type = titlesDtoBase.type,                
                price = titlesDtoBase.price,
                advance = titlesDtoBase.advance,
                royalty = titlesDtoBase.royalty,
                ytd_sales = titlesDtoBase.ytd_sales,
                notes = titlesDtoBase.notes               
            };
        }
        public static Titles ConvertDtoCreateToEntity(TitlesDtoAdd titlesDtoAdd)
        {
            Titles titles = ConvertDtoToGetEntity(titlesDtoAdd);
            titles.pub_id = titlesDtoAdd.pub_id;
            titles.pubdate = titlesDtoAdd.pubdate;
            titles.creationUser = titlesDtoAdd.UserId;
            titles.creationDate = titlesDtoAdd.modifyDate;
            return titles;
        }
        public static Titles ConvertDtoUpdateToEntity(TitlesDtoUpdate titlesDtoUpdate)
        {
            Titles titles = ConvertDtoToGetEntity(titlesDtoUpdate);            
            titles.userMod = titlesDtoUpdate.UserId;
            titles.modifyDate = titlesDtoUpdate.modifyDate;
            return titles;
        }
        public static Titles ConvertDtoDeleteToEntity(TitlesDtoDelete titlesDtoDelete)
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
