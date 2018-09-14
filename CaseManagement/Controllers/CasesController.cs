using CaseManagement.Models.Cases;
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
    public class CasesController : Controller
    {
        private ICase _cases;
        private IStatus _status;
        private IUser _users;
        private IApplicant _applicants;

        public CasesController(ICase cases, IUser users, IApplicant applicants, IStatus status)
        {
            _status = status;
            _cases = cases;
            _users = users;
            _applicants = applicants;
            // injected dependancy into patron contorller
        }

        public IActionResult CreatePage(int id, int applicantId)
        {
            Case model = new Case
            {
               User = _users.Get(Convert.ToInt16(User.Claims.ElementAt(0).Value)),
               Applicant = _applicants.Get(applicantId)
            };

           

            // start building case with partial information passed from Applicant Table -> Create Case

            return View(model);
        }


        [HttpPost]
        public IActionResult Create([Bind("LoanAmount,OfferToPurchaseDoc,Applicant,User,Status,CaseSlaBreach")] Case cases, int applicantid, int userid)
        {
            // server side pagenation ? 
            cases.Applicant = _applicants.Get(applicantid);
            cases.User =  _users.Get( userid);
            cases.DateCreated = DateTime.Now;
            cases.Status = _status.Get("Created");
            _cases.Add(cases);
           
            Task.WaitAll(Task.Delay(1000));
            return  RedirectToAction("Index", "Applicant", new { id = userid });
        }

        [Authorize]
        public IActionResult CurrentCases()
        {
            var cases = _cases.GetCases((Convert.ToInt16(User.Claims.ElementAt(0).Value)));
           
            var model = new CasesIndexModel
            {
                Cases = cases
            };

            return View(model);
        }
    }
}
