using CaseManagementData;
using CaseManagementData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseManagementServices
{
    public class SubmissionService : ISubmission
    {
        private CaseManagementContext _context;
        private ICase _cases;
        private IStatus _status;


        public SubmissionService(CaseManagementContext context, ICase cases, IStatus status)
        {
            _context = context;
            _cases = cases;
            _status = status;
      
        }

        public void Add(Submission newSubmission)
        {
            _context.Submissions.Add(newSubmission);
            _context.SaveChanges();
        }

        public Submission Get(int id)
        {
            return _context.Submissions
                .Include(s => s.Bank)
                .Include(s => s.Case)
                .Include(s => s.Status)
                 .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Submission> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Submission> GetSubmissionsForCase(int caseId)
        {
            Case caseTemp = _context.Cases

                .FirstOrDefault(c => c.Id == caseId);

            return _context.Submissions
                .Include(s => s.Bank)
                .Include(s => s.Case)
                .Include(s => s.Status)
                .Where(s => s.Case == caseTemp);
            
        }

        public void UpdateSubmissionStatus(Submission submission, string status)
        {
            
            _context.Submissions.FirstOrDefault(s => s.Id == submission.Id).Status = _context.Statuses.FirstOrDefault(s => s.Name == status);
            _context.SaveChanges();
            
          
        }

        public void UpdateResponseFields(Submission submission)
        {

            _context.Submissions.FirstOrDefault(s => s.Id == submission.Id).OfferedAmount = submission.OfferedAmount;
            _context.Submissions.FirstOrDefault(s => s.Id == submission.Id).OfferedInterestRate = submission.OfferedInterestRate;
            _context.Submissions.FirstOrDefault(s => s.Id == submission.Id).OfferedPeriod = submission.OfferedPeriod;
            _context.Submissions.FirstOrDefault(s => s.Id == submission.Id).BankResponseDoc = submission.BankResponseDoc;
            
            _context.SaveChanges();


        }



        public IEnumerable<Submission> GetBreachedSubmissions(int userId)
        {
            IEnumerable<Case> cases = _cases.GetCases(userId);
            List<Submission> allBreachedSubmissions = new List<Submission>();

            foreach (Case c in cases)
            {
                List<Submission> breachedSubmissions = _context.Submissions
                .Include(s => s.Bank)
                .Include(s => s.Case)
                .Include(s => s.Status)
                .Where(s => (System.DateTime.Now - s.DateSubmitted).Days > 2)
                                                               .Where(s => s.Status == _status.Get("Submitted") ).ToList();



            
                if(breachedSubmissions.Any())
                {
                    foreach (Submission s in breachedSubmissions)
                    {
                        allBreachedSubmissions.Add(s);
                    }
                }

            }


            return allBreachedSubmissions;
        }

        public IEnumerable<Submission> GetSubmissionsOfStatus(string status)
        {
            return _context.Submissions.Where(s => s.Status == _context.Statuses.FirstOrDefault(sub => sub.Name == status));
        }


        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

}
