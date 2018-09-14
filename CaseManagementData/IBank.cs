using CaseManagementData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagementData
{
    public interface IBank
    {
        IEnumerable <Bank> GetAll();
        Bank Get(string name);
    }
}
