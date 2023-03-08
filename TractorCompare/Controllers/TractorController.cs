using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TractorCompare.Models;

namespace TractorCompare.Controllers
{
    public class TractorController : Controller
    {
        private readonly ITractorRepository repo;

        public TractorController(ITractorRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var tractors = repo.GetAllTractors();
            return View(tractors);
        }

        public IActionResult ViewTractor(int id)
        {
            var tractor = repo.GetTractor(id);

            return View(tractor);

        }

        public IActionResult UpdateTractor(int id)
        {
            Tractors make = repo.GetTractor(id);
            if (make == null)
            {
                return View("ProductNotFound");
            }
            return View(make);
        }

        public IActionResult UpdateTractorToDatabase(Tractors tractor)
        {
            repo.UpdateTractor(tractor);

            return RedirectToAction("ViewTractor", new {id = tractor.tractorID});
        }

        public IActionResult JohnDeere() 
        {
            var johndeere = repo.GetJD();

            return View(johndeere);
        }
    }
}
