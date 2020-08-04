using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers
                .ToList(); 

            return View(employers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            
            return View(addEmployerViewModel);
        }

        [HttpPost] 
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel) 
        {
            if (ModelState.IsValid)
            {
                Employer newEmployers = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                context.Add(newEmployers);
                return Redirect("/Employer/About"); 
            }
            return View(addEmployerViewModel);
        }

        //TODO: 1. Fix Lambda expression!?!
        public IActionResult About(int id)
        {
            List<Employer> employers = context.Employers
                .Where(e => e.Id== id)  //<--  EmployerId (from Job Model)??
                .Include(e => e.Name)
                .Include(e => e.Location)
                .ToList();

            return View(employers);
        }

    }
}
