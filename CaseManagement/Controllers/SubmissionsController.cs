using CaseManagement.Models.Submissions;
using CaseManagementData;
using CaseManagementData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;


namespace CaseManagement.Controllers
{
    public class SubmissionsController: Controller
    {
       
            private ICase _cases;
            private IStatus _status;
            private IUser _users;
            private IApplicant _applicants;
        private IBank _banks;
        private ISubmission _submissions;

            public SubmissionsController(ICase cases, IUser users, IApplicant applicants, IStatus status, IBank banks, ISubmission submissions)
            {
                _status = status;
                _cases = cases;
                _users = users;
                _applicants = applicants;
            _banks = banks;
            _submissions = submissions;
                // injected dependancy into patron contorller
            }

            public IActionResult CreatePage(int caseId)
            {
                var model = new SubmissionDetailModel
                {
                    banks = _banks.GetAll(),
                    submission = new Submission
                    {
                        Case = _cases.Get(caseId)
                    },
                    previous_submissions = _submissions.GetSubmissionsForCase(caseId)

                };

                return View(model);
            }


           [HttpPost]
            public IActionResult Create(int caseid, string bankname)
            {
            // server side pagenation ?
            Submission submission = new Submission()
            {
                DateSubmitted = DateTime.Now,
                Case = _cases.Get(caseid),
                Bank = _banks.Get(bankname),
              Status = _status.Get("Submitted")

        }
            ;
           
            _submissions.Add(submission);
            _cases.UpdateCaseStatus(submission.Case, "In Progress");
            
                Task.WaitAll(Task.Delay(1000));
                return RedirectToAction("CreatePage", "Submissions", new { caseId = caseid });
            }


            public IActionResult CurrentCases(int id)
            { 
                return View(null);
            }

        public IActionResult UpdateSubmissionPage(int submissionid)
        {
            var submission_detail = new SubmissionDetailModel
            {
                statuses = _status.GetSubmissionStatuses(),
                submission = _submissions.Get(submissionid)
            };
       
            return View(submission_detail);
        }

       
      /*  public IActionResult UpdateSubmission(int submissionid, string OfferedAmount, string OfferedInterestRate, string OfferedPeriod, bool BankResponseDoc)
        {


            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ",";

            OfferedAmount = OfferedAmount.Replace(".", ",");
            OfferedInterestRate = OfferedInterestRate.Replace(".", ",");
            OfferedPeriod =  OfferedPeriod.Replace(".", ",");
            Submission temp = new Submission()
            {
                Id = submissionid,
                OfferedAmount = Convert.ToDecimal(OfferedAmount),
                OfferedInterestRate = Convert.ToDecimal(OfferedInterestRate),
                OfferedPeriod = Convert.ToDecimal(OfferedPeriod),
                BankResponseDoc = BankResponseDoc
                
            };
           
          _submissions.UpdateResponseFields(temp);
            Submission sub = _submissions.Get(submissionid);
            _submissions.UpdateSubmissionStatus("")
            return RedirectToAction("CreatePage", "Submissions", new { caseId = sub.Case.Id });
        }
        */

        [HttpPost]
        public IActionResult UpdateSubmission(int submissionid, string statusname, [Bind("OfferedAmount, OfferedPeriod, OfferedInterestRate, BankDoc")] SubmissionDetailModel submissionDetail)
        {
            Submission thisSubmission = _submissions.Get(submissionid);
            Status thisStatus = _status.Get(statusname);

            thisSubmission.Status = thisStatus;
            thisSubmission.OfferedAmount = submissionDetail.OfferedAmount;
            thisSubmission.OfferedInterestRate = submissionDetail.OfferedInterestRate;
            thisSubmission.OfferedPeriod = submissionDetail.OfferedPeriod;
            thisSubmission.BankResponseDoc = submissionDetail.BankDoc;
            _submissions.SaveChanges();


            return RedirectToAction("CreatePage", "Submissions", new { caseId = thisSubmission.Case.Id });
        }



    }

}
