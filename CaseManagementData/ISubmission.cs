using CaseManagementData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagementData
{
    public interface ISubmission
    {

        Submission Get(int id);
        IEnumerable<Submission> GetAll();

        void Add(Submission newSubmission);
        void UpdateSubmissionStatus(Submission submission, string status);
        void UpdateResponseFields(Submission submission);
        void SaveChanges();
        IEnumerable<Submission> GetSubmissionsOfStatus(string status);
        IEnumerable<Submission> GetSubmissionsForCase(int caseId);
    }
}
