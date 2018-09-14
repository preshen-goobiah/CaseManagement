using CaseManagementData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagementData
{
    public interface IApplicant
    {
        Applicant Get(int id);
        IEnumerable<Applicant> GetAll();
        IEnumerable<Applicant> SearchApplicant(string name);
        void Add(Applicant newApplicant);

        IEnumerable<Case> GetCases(int id);
       

    }
}
