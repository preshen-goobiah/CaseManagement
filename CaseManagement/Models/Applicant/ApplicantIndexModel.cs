using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Models.Applicant
{
    public class ApplicantIndexModel
    {
        public IEnumerable<CaseManagementData.Models.Applicant> Applicants { get; set; } 
    }
}
