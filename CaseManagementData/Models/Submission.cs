using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagementData.Models
{
   public class Submission
    {
        public int Id { get; set; }
        public Case Case { get; set; }
        public Bank Bank { get; set; }
        
        public Status Status { get; set; }
        public DateTime DateSubmitted { get; set; }
        public bool BankResponseDoc { get; set; }
        public decimal OfferedAmount { get; set; }
        public decimal OfferedInterestRate { get; set; }
        public decimal OfferedPeriod { get; set; }
        public bool IsAccepted { get; set; }
        public bool SubmissionSlaBreach { get; set; }
        public DateTime BankResponseDateTime { get; set; }



    }
}
