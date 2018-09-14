using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaseManagementData.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        [RegularExpression(@"^[0-9]{13}$", ErrorMessage = "Valid ID numbers only")]
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Income { get; set; }
        public IncomeType IncomeType { get; set; }
        public int Credit { get; set; }
        public CreditScore CreditScore { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string Cellphone { get; set; }
        

        public IEnumerable<Case> Cases {get;set;}



        

    }
}
