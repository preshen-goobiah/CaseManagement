using CaseManagement.Models.Applicant;

using CaseManagementData;
using CaseManagementData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    public class ApplicantController : Controller
    {
        
        private IApplicant _applicant;
        public ApplicantController(IApplicant applicant)
        {
            _applicant = applicant;
            // injected dependancy into  contorller
        }
        [Authorize]
        public IActionResult Index()
        {
            // server side pagenation ? 
          
            var allApplicants = _applicant.GetAll();

            var model = new ApplicantIndexModel()
            {
                Applicants = allApplicants
            };

            
            return View(model);
        }

     


        

        public IActionResult Add()
        {
            // use user id
            return View(null);
        }

        [HttpPost]
        public IActionResult Create([Bind("IdNumber,FirstName,LastName,Income,IncomeTypeId,Credit,DateOfBirth, Email, Cellphone")] Applicant applicant)
        {
            // server side pagenation ? 
            _applicant.Add(applicant);
            Task.WaitAll(Task.Delay(1000));
            return RedirectToAction("Add");
        }


        [HttpPost]
        public IActionResult Search(string searchString)
        {
           

            ApplicantIndexModel model = new ApplicantIndexModel()
            {
                Applicants = _applicant.SearchApplicant(searchString)
        };

            return View("Index", model);
        }
    }
}
