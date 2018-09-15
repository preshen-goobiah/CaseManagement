using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Home
{
    public class HomeDetailModel
    {
       
        public IEnumerable<CaseManagementData.Models.Case> Cases { get; set; }
        public IEnumerable<CaseManagementData.Models.Submission> Submissions { get; set; }

    }
}
