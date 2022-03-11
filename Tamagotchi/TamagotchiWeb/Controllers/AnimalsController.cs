﻿using Microsoft.AspNetCore.Mvc;
using TamagotchiWeb.Data;
using TamagotchiWeb.Models;
using TamagotchiWeb.Services;
using TamagotchiWeb.Services.DTOs.OutPut.Common;

namespace TamagotchiWeb.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly Context _db;
        public AnimalsController(Context db)
        {
            _db = db;
            _animalService = new AnimalService();
        }
        public IActionResult Index()
        {
            var result = new GetAnimals
            {
                //Animals = _db.Animals,
                Pagination = new Pagination
                {
                    total_count = _db.Animals.Count()
                }
            };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Synch(string gg)
        {
            //var firstRequest = await _animalService.GetAnimals(1);

            for (int i = 1301; i <= 1400; i++)
            {
                var answer = await _animalService.GetAnimals(i);

                foreach (var item in answer.Animals)
                {
                    _db.Animals.Add(item);
                }

                _db.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}