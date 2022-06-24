using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogGo.Models;
using DogGo.Repositories;
using DogGo.Models.ViewModels;
using System;

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
        private readonly IDogRepository _dogRepo;
        private readonly IWalkerRepository _walkerRepo;
        // ASP.NET will give us an instance of our Dog Repository. This is called "Dependency Injection"
        public WalksController(IWalkRepository walkRepository, IDogRepository dogRepo, IWalkerRepository walkerRepo)
        {
            _walkRepo = walkRepository;
            _dogRepo = dogRepo; 
            _walkerRepo = walkerRepo;
        }

        // GET: WalkController/Create
        public ActionResult Create()
        {
            List<Dog> dogs = _dogRepo.GetAllDogs();
            List<Walker> walkers = _walkerRepo.GetAllWalkers();

            WalkerFormViewModel wvm = new WalkerFormViewModel()
            {
                Walk = new Walk(),
                Walkers = walkers,
                Dogs = dogs
            };

            return View(wvm);
        }

        // POST: WalkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Walk walk)
        {
            try
            {
                _walkRepo.AddWalk(walk);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(walk);
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
