using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogGo.Repositories;
using DogGo.Models;
using System.Collections.Generic;
using DogGo.Models.ViewModels;
using System.Security.Claims;
using System;


namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        // GET: WalkersController
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();
            if (ownerId == 004)
            {
                List<Walker> walkers = _walkerRepo.GetAllWalkers();

                return View(walkers);
            }
            else
            {
                Owner owner = _ownerRepo.GetOwnerById(ownerId);
                int neId = owner.NeighborhoodId;

                List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(neId);

                return View(walkers);

            }
        }

        // GET: WalkersController/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);
            List<Walk> walks = _walkRepo.GetWalksByWalkerId(id);
            TotalWalkTime totalWalkTime = new TotalWalkTime(walks);

            if (walker == null)
            {
                return NotFound();
            }
            WalkerViewModel wvm = new WalkerViewModel()
            {
                Walker = walker,
                Walks = walks,
                TotalWalkTime = totalWalkTime
            };

            return View(wvm);
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalkRepository _walkRepo;
        private readonly IOwnerRepository _ownerRepo;

        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalkersController(IWalkerRepository walkerRepository, IWalkRepository walkRepository, IOwnerRepository ownerRepo)
        {
            _walkerRepo = walkerRepository;
            _walkRepo = walkRepository;
            _ownerRepo = ownerRepo;
        }

        // POST: WalkersController/Create
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

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
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

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
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

        private int GetCurrentUserId()
        {

            try
            {
                string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return int.Parse(id);
            }
            catch (ArgumentNullException ex)
            {
                int noUser = 004;
                return noUser;
            }

        }
    }
}
