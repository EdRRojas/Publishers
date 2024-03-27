using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using publishers.Application.Dtos.Titles;
using publishers.Web.Models.Titles;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Text.Json.Serialization;

namespace publishers.Web.Controllers
{
    public class TitlesController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        public TitlesController()
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyError) => { return true; };
        }
        // GET: TitlesController
        public async Task<IActionResult> Index()
        {
            var title = new TitleListResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = "http://localhost:5171/api/Titles/GetTitles";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        title = JsonConvert.DeserializeObject<TitleListResult>(apiResponse);

                        if (!title.success)
                        {
                            ViewBag.Message = title.message;
                            return View();
                        }
                    }
                }
            }

            return View(title.data);
        }

        // GET: TitlesController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var title = new TitleDetailView(); 
            
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5171/api/Titles/GetTitle?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        title = JsonConvert.DeserializeObject<TitleDetailView>(apiResponse);

                        if (!title.success)
                        {
                            ViewBag.Message = title.message;
                            return View();
                        }
                    }
                }
            }
            return View(title.data);
        }

        // GET: TitlesController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TitlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TitlesDtoAdd titlesDtoAdd)
        {
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = $"http://localhost:5171/api/Titles/CreateTitle";

                    titlesDtoAdd.UserId = 20220847;
                    titlesDtoAdd.modifyDate = DateTime.Now;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(titlesDtoAdd), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TitlesController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var title = new TitleDetailView();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5171/api/Titles/GetTitle?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        title = JsonConvert.DeserializeObject<TitleDetailView>(apiResponse);

                        if (!title.success)
                        {
                            ViewBag.Message = title.message;
                            return View();
                        }
                    }
                }
            }

            return View(title.data);
        }

        // POST: TitlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TitlesDtoUpdate titlesDtoUpdate)
        {
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = $"http://localhost:5171/api/Titles/TitlesUpdate";

                    titlesDtoUpdate.UserId = 20220847;
                    titlesDtoUpdate.modifyDate = DateTime.Now; 

                    StringContent content = new StringContent(JsonConvert.SerializeObject(titlesDtoUpdate), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync(url, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TitlesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TitlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
