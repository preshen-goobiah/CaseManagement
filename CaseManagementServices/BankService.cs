using CaseManagementData;
using CaseManagementData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseManagementServices
{
    public class BankService : IBank
    {
        private CaseManagementContext _context;

        public BankService(CaseManagementContext context)
        {
            _context = context;
        }

        public Bank Get(string name)
        {
            return _context.Banks
                .FirstOrDefault(b => b.Name == name);
        }

        public IEnumerable <Bank> GetAll()
        {
            return _context.Banks;
        }
    }
}
