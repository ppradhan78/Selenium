using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Selenium.MVC.Core;
using Selenium.MVC.Models;

namespace Selenium.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryCore _categoryCore;
        public CategoryController(ICategoryCore categoryCore)
        {
            _categoryCore = categoryCore;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categoryCore.GetList());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(_categoryCore.GetById(id));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategorySampleModel input)
        {
            try
            {
                _categoryCore.SaveCategory(input);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_categoryCore.GetById(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategorySampleModel input)
        {
            try
            {
                _categoryCore.SaveCategory(input);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_categoryCore.GetById(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _categoryCore.GetById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
