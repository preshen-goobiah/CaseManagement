using CaseManagementData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Models.Submissions
{
    public class SubmissionDetailModel
    {
        public IEnumerable<Bank> banks { get; set; }
        public Submission  submission { get; set; }
        public  IEnumerable<Submission> previous_submissions { get; set; }
        public IEnumerable<Status> statuses { get; set; }
        public decimal OfferedAmount { get; set; }
        public decimal OfferedInterestRate { get; set; }
        public decimal OfferedPeriod { get; set; }
        public string StatusName { get; set; }
        public bool BankDoc { get; set; }
        // add fields to intepet in update submission controller
    }
}
