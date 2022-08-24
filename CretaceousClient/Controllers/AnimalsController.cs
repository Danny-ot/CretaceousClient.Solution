using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CretaceousClient.Models;

namespace CretaceousClient.Controllers
{
    public class AnimalsController :Controller
    {
        public  IActionResult Index()
        {
            var model = Animal.GetAnimals();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = Animal.GetDetails(id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            Animal.AddAnimal(animal);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var animal = Animal.GetDetails(id);
            return View(animal);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            Animal.UpdateAnimal(animal);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {        
            var animal = Animal.GetDetails(id);
            return View(animal);
        }

        [HttpPost , ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Animal.DeleteAnimal(id);
            return RedirectToAction("Index");
        }
    }
}