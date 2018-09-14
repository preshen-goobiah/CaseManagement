using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Models.Cases
{
    public class CasesIndexModel
    {
        public IEnumerable<CaseManagementData.Models.Case> Cases { get; set; }
    }
}
