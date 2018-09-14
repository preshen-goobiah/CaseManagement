using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaseManagementData.Models
{
    public class Case
    {
        public int Id { get; set; }
        [Range(0, 1500000)]// from feedback restict loan amount as stated in assumotions. P.S need to add valadation on front end
        public Decimal LoanAmount { get; set; }
        public bool OfferToPurchaseDoc { get; set; }
        
        public Applicant Applicant { get; set; }
        public User User { get; set; }
        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<Submission> Submissions { get; set; }
        public bool CaseSlaBreach { get; set; }



    }
}
