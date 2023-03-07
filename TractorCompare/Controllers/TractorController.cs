using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}
