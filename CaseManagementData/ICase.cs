using CaseManagementData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagementData
{
    public interface ICase
    {

        Case Get(int id);
        IEnumerable<Case> GetAll();
        void Add(Case newCase);
        void UpdateCaseStatus(Case cases, string status);


        IEnumerable<Case> GetCases(int id);

        // get cases for specific user

        IEnumerable<Case> GetBreachedCases(int userId);
        // get breached cases 


    }
}
