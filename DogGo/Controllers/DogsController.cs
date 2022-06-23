﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using DogGo.Repositories;
using DogGo.Models;
using System.Collections.Generic;
using System;

namespace DogGo.Controllers
{
    public class DogsController : Controller
    {
        // GET: DogsController
        [Authorize]
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();
            List<Dog> dogs = _dogRepo.GetDogsByOwnerId(ownerId);
            return View(dogs);
        }

        // GET: DogsController/Details/5
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);
            if(dog == null)
            {
                return NotFound();
            }
            return View(dog);
        }

        private readonly IDogRepository _dogRepo;
        private readonly IOwnerRepository _ownerRepo;

        // ASP.NET will give us an instance of our Dog Repository. This is called "Dependency Injection"
        public DogsController(IDogRepository dogRepository, IOwnerRepository ownerRepo)
        {
            _dogRepo = dogRepository;
            _ownerRepo = ownerRepo;
        }


        // GET: DogsController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            try
            {
                // update the dogs OwnerId to the current user's Id
                dog.OwnerId = GetCurrentUserId();
                _dogRepo.AddDog(dog);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(dog);
            }
        }

        // GET: DogsController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            int ownerId = GetCurrentUserId();
            Dog dog = _dogRepo.GetDogById(id);
            
            if(dog.OwnerId != ownerId)
            {
                return NotFound();
            }
            if(dog == null)
            {
                return NotFound();
            }
            return View(dog);
        }

        // POST: DogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                _dogRepo.UpdateDog(dog);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(dog);
            }
        }

        // GET: DogsController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            int ownerId = GetCurrentUserId();
            Dog dog = _dogRepo.GetDogById(id);

            if (dog.OwnerId != ownerId)
            {
                return NotFound();
            }
            if (dog == null)
            {
                return NotFound();
            }
            return View(dog);
        }

        // POST: DogsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                _dogRepo.DeleteDog(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dog);
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
