using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }  

        [Required(ErrorMessage ="ID is required.")]
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public List<int> SkillId { get; set; }
        public List<Skill> Skill { get; set; }

        public AddJobViewModel()
        { 
        
        }

        public AddJobViewModel(List<Employer> employers, List<Skill> skill)
        {
            Employers = new List<SelectListItem>();
            foreach (var e in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                });
            }
            Skill = skill;
        }    


    }
}

