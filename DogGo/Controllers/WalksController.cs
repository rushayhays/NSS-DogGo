using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogGo.Models;
using DogGo.Repositories;

namespace DogGo.Controllers
{
    public class WalksController : Controller
    {
        // GET: WalksController
        public ActionResult Index()
        {
            List<Walk> walks = _walkRepo.GetAllWalksForIndex();
            return View(walks);
        }

        // GET: WalkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private readonly IWalkRepository _walkRepo;
        // ASP.NET will give us an instance of our Dog Repository. This is called "Dependency Injection"
        public WalksController(IWalkRepository walkRepository)
        {
            _walkRepo = walkRepository;
        }

        // GET: WalkController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkController/Create
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

        // GET: WalkController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkController/Edit/5
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

        // GET: WalkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkController/Delete/5
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
