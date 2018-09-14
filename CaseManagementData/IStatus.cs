using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagementData.Models
{
    public interface IStatus
    {
        void Add(Status newStatus);
        Status Get(string name);
        IEnumerable<Status> GetAll();
        IEnumerable<Status> GetSubmissionStatuses();
    }
}
