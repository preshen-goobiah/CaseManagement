using CaseManagementData;
using CaseManagementData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseManagementServices
{
    public class CaseService : ICase
    {

        private CaseManagementContext _context;

        public CaseService(CaseManagementContext context)
        {
            _context = context;
        }
        public void Add(Case newCase)
        {
            _context.Add(newCase);
            _context.SaveChanges();
        }

        public Case Get(int id)
        {
            // get case by id
            return _context.Cases
                .Include(c => c.Submissions)
                .Include(c => c.Applicant)
                .Include(c => c.Status)
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Case> GetAll()
        {
            return _context.Cases
                .Include(c => c.Submissions)
                .Include(c => c.Applicant)
                 .Include(c => c.Status);
        }

        public IEnumerable<Case> GetCases(int id)
        {

            // get cases by user id
            return _context.Cases
                .Include(c => c.Submissions)
                .Include(c => c.Applicant)
                 .Include(c => c.Status)
                .Where(c => c.User.Id == id);
        }

        public void UpdateCaseStatus(Case cases, string status)
        {
          
            _context.Cases.FirstOrDefault(c => c.Id == cases.Id).Status = 
                _context.Statuses.FirstOrDefault(s => s.Name == status);
            _context.SaveChanges();
        }
    }
}
