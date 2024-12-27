using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appPDWebMVC.Controllers
{
    public class IndumentariumsController : Controller
    {
        // GET: IndumentariumsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IndumentariumsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndumentariumsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndumentariumsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: IndumentariumsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndumentariumsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: IndumentariumsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndumentariumsController/Delete/5
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
