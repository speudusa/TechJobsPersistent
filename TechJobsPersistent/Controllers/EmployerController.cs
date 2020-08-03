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
            Employer employers = context.Employers.ToList();  //am i making a list here?
            return View(employers);
        }

        [HttpPost]
        public IActionResult Add(AddEmployerViewModel addEmployerViewModel)
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel
            {
                Name = addEmployerViewModel.Name,
                Location = addEmployerViewModel.Location
            }; 

            //what am I adding this to???
            return View(addEmployerViewModel);
        }

        //TODO: Add the appropriate code to ProcessAddEmployerForm() 
            //so that it will process form submissions and make sure that 
            //only valid Employer objects are being saved to the database

            //Chapter 15  - both viewModels & validation

        [HttpPost] 
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel) //UPDATE with LIST of Employers
        {
            if (ModelState.IsValid)
            {
                context.AddEmployerViewModel.Add();  //not sure what to do with this 
                context.SaveChanges();
                return Redirect("/Employers/"); 
            }

            return View("Add", addEmployerViewModel);
        }

        //TODO: About() currently returns a view with vital information 
            //about each employer such as their name and location. Make sure 
            //that the method is actually passing an Employer OBJECT to the 
            //view for display

        public IActionResult About(int id)
        {
            Employer employers = (Employer)context.Employers
                .Where(emp => emp.Id == id)
                .Include(emp => emp.Name)
                .Include(emp => emp.Location);

            return View(employers);
        }

    }
}
