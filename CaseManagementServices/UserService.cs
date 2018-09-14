using CaseManagementData;
using CaseManagementData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseManagementServices
{
    public class UserService : IUser
    {
        private CaseManagementContext _context;

        public UserService(CaseManagementContext context)
        {
            _context = context;
        }
        public void Add(User newUser)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return _context.Users
                .Include(u => u.Cases)
                .Include(u => u.Position)
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
