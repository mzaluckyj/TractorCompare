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

        public IActionResult Index(string searchString, string filter)
        {

            var tractors = repo.GetAllTractors();


            ViewData["%CurrentFilter%"] = searchString;
            ViewBag.BrandSort = String.IsNullOrEmpty(filter) ? "brand_desc" : "";
            ViewBag.HPSort = String.IsNullOrEmpty(filter) ? "hp_desc" : "";
            ViewBag.ClassSort = String.IsNullOrEmpty(filter) ? "class_desc" : "";
            ViewBag.All = "All";
            ViewBag.JD = "John Deere";
            ViewBag.Kub = "Kubota";
            ViewBag.Kiot = "Kioti";
            ViewBag.Sub = "Sub";
            ViewBag.SF = "SF";
            ViewBag.SC = "SC";
            ViewBag.Com = "Com";


            switch (filter)
            {
                case "brand_desc":
                    tractors = tractors.OrderBy(t => t.brand);
                    break;
                case "class_desc":
                    tractors = tractors.OrderBy(t => t.Class);
                    break;
                case "hp_desc":
                    tractors = tractors.OrderBy(t => t.HP);
                    break;
                case "John Deere":
                    tractors = tractors.Where(t => t.brand.Equals("John Deere"));
                    break;
                case "Kubota":
                    tractors = tractors.Where(t => t.brand.Equals("Kubota"));
                    break;
                case "Kioti":
                    tractors = tractors.Where(t => t.brand.Equals("Kioti"));
                    break;
                case "Sub":
                    tractors = tractors.Where(t => t.Class.Equals("1. Sub-Compact"));
                    break;
                case "SF":
                    tractors = tractors.Where(t => t.Class.Equals("2. Small Frame"));
                    break;
                case "SC":
                    tractors = tractors.Where(t => t.Class.Equals("2. Small Compact"));
                    break;
                case "Com":
                    tractors = tractors.Where(t => t.Class.Equals("3. Compact"));
                    break;
                default:
                    tractors = tractors.OrderBy(t => t.brand);
                    break;
            }




            if (!String.IsNullOrEmpty(searchString))
            {
                tractors = tractors.Where(t => t.Model.Contains(searchString));
            }

            return View(tractors);
        }


        public IActionResult Compare(string model1, string model2)
        {
            var tractors = from t in repo.CompareNow() select t;
            

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
    }
}
