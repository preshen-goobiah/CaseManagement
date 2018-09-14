using CaseManagementData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagementData
{
    public interface IUser
    {
        User Get(int id);
        IEnumerable<User> GetAll();
        void Add(User newUser);

       
    }
}
