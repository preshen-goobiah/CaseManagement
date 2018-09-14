using CaseManagementData;
using CaseManagementData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseManagementServices
{
    public class StatusService : IStatus
    {
        private CaseManagementContext _context;

        public StatusService(CaseManagementContext context)
        {
            _context = context;
        }

        public void Add(Status newStatus)
        {
            _context.Add(newStatus);
            _context.SaveChanges();
        }

        public Status Get(string name)
        {
            return _context.Statuses.FirstOrDefault(s => s.Name == name);
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Statuses;
        }

        public IEnumerable<Status> GetSubmissionStatuses()
        {

            return _context.Statuses.Where(s => s.Name == "Full Grant" || s.Name == "Declined-Affordability" || s.Name == "Declined-Scoring");

        }
    }
}
