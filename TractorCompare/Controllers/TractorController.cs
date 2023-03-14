using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index(string searchString, string brands)
        {

            var tractors = repo.GetAllTractors();
            ViewData["%CurrentFilter%"] = searchString;
            ViewData["brands"] = brands;

            if (!String.IsNullOrEmpty(searchString))
            {
                tractors = tractors.Where(t => t.brandID.Contains(searchString));
            }


           
            if (!String.IsNullOrEmpty(brands))
            {
                tractors = tractors.Where(t => t.brandID.Equals(brands));
            }



            return View(tractors);
            

        }
       // public IActionResult Index()
       // {
       //  var tractors = repo.GetAllTractors();
       //   return View(tractors);
       // }

        public IActionResult Compare(string model1, string model2)
        {
            ViewData["Model1"] = model1;
            ViewData["Model2"] = model2;

            var tractors = from t in repo.CompareNow() select t;
            

            if (!String.IsNullOrEmpty(model1))
            {
                tractors = tractors.Where(t => t.Model.Contains(model1));
            }

            if (!String.IsNullOrEmpty(model2))
            {
                tractors = tractors.Where(x => x.Model.Contains(model2));
                
            }

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
           var jd = repo.GetJD();

            return View(jd);
        }

        public IActionResult Kubota()
        {
            var kubota = repo.GetKubota();

            return View(kubota);
        }

        public IActionResult InsertTractor()
        {
            var trac = repo.AssignBrand();
            return View(trac);
        }

        public IActionResult InsertTractorToDB(Tractors newtractor) 
        {
            repo.InsertTractor(newtractor);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTractor(Tractors tractors) 
        {
            repo.DeleteTractor(tractors);
            return RedirectToAction("Index");
        }

    }
}
