using Microsoft.AspNetCore.Mvc;
using publishers.Application.Dtos.Titles;
using publishers.Web.Models.Titles;
using publishers.Web.Services;

namespace publishers.Web.Controllers
{
    public class TitlesController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ITitlesServices titlesServices;

        public TitlesController(ITitlesServices titlesServices)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyError) => { return true; };
            this.titlesServices = titlesServices;
        }
        // GET: TitlesController
        public async Task<IActionResult> Index()
        {
            var title = new TitleListResult();

            title = await this.titlesServices.GetAll();            

            return View(title.data);
        }

        // GET: TitlesController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var title = new TitleDetailView();

            title = await this.titlesServices.Get(id);

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
                var result = await this.titlesServices.Create(titlesDtoAdd);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
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

            title = await this.titlesServices.Get(id);

            return View(title.data);
        }

        // POST: TitlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TitlesDtoUpdate titlesDtoUpdate)
        {
            try
            {
                var result = await this.titlesServices.Update(titlesDtoUpdate);                

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
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
