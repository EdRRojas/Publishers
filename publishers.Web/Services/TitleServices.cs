using publishers.Application.Core;
using publishers.Application.Dtos.Titles;
using publishers.Web.Models.Titles;
using System.Text;

namespace publishers.Web.Services
{
    public class TitleServices : ITitlesServices
    {
        private string BaseURL;
        private IConfiguration configuration;
        private readonly ILogger<TitleServices> logger;
        private readonly IHttpClientFactory httpClientFactory;

        public TitleServices(IConfiguration configuration, ILogger<TitleServices> logger, IHttpClientFactory httpClientFactory)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            this.BaseURL = this.configuration["ApiConfiguration:BaseURL"];
        }
        public async Task<ServicesResult<TitlesDtoAdd>> Create (TitlesDtoAdd dtoAdd)
        {
            ServicesResult <TitlesDtoAdd> result = new ServicesResult<TitlesDtoAdd>();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    string url = $"{this.BaseURL}/Titles/CreateTitle";

                    dtoAdd.UserId = 20220847;
                    dtoAdd.modifyDate = DateTime.Now;

                    StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dtoAdd), Encoding.UTF8, "application/json");

                    string apiResponse = string.Empty;

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            apiResponse = await response.Content.ReadAsStringAsync();
                            result = System.Text.Json.JsonSerializer.Deserialize<ServicesResult<TitlesDtoAdd>>(apiResponse);
                        }
                        else
                        {
                            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                apiResponse = await response.Content.ReadAsStringAsync();
                                result = System.Text.Json.JsonSerializer.Deserialize<ServicesResult<TitlesDtoAdd>>(apiResponse);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al registrar el libro: ";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<TitleDetailView> Get(string id)
        {
            TitleDetailView result = new TitleDetailView();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    string url = $"{this.BaseURL}/Titles/GetTitle?id={id}";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            result = System.Text.Json.JsonSerializer.Deserialize<TitleDetailView>(apiResponse);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Ocurrio un error al obtner los libros";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error al obtener el libro: ";
                this.logger.LogError(result.message, ex.ToString());
            }

            return result;
        }

        public  async Task<TitleListResult> GetAll()
        {
            var title = new TitleListResult();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    string url = $"{this.BaseURL}/Titles/GetTitles";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if(response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            title = System.Text.Json.JsonSerializer.Deserialize<TitleListResult>(apiResponse);
                        }
                        else
                        {
                            title.success = false;
                            title.message = "Ocurrio un error al obtner los libros";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                title.success = false;
                title.message = "Ocurrio un error al intentar obtener los libros: ";
                this.logger.LogError(title.message, ex.ToString());
            }

            return title;
        }

        public async Task<ServicesResult<TitlesDtoUpdate>> Update(TitlesDtoUpdate dtoUpdate)
        {
            ServicesResult<TitlesDtoUpdate> result = new ServicesResult<TitlesDtoUpdate>();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    string url = $"{this.BaseURL}/Titles/TitlesUpdate";

                    dtoUpdate.UserId = 20220847;
                    dtoUpdate.modifyDate = DateTime.Now;

                    StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dtoUpdate), Encoding.UTF8, "application/json");

                    string apiResponse = string.Empty;

                    using (var response = await httpClient.PutAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            apiResponse = await response.Content.ReadAsStringAsync();
                            result = System.Text.Json.JsonSerializer.Deserialize<ServicesResult<TitlesDtoUpdate>>(apiResponse);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                apiResponse = await response.Content.ReadAsStringAsync();
                                result = System.Text.Json.JsonSerializer.Deserialize<ServicesResult<TitlesDtoUpdate>>(apiResponse);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el libro: ";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
