using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagementData.Models
{
    public class User
    {
        public int Id {get; set; }
        public string Email {get; set; }
        public string Password { get; set; }
        public string FirstName {get; set; }
        public string LastName { get; set; }
        public Position Position {get; set; }
    

        public IEnumerable<Case> Cases { get; set; }
       // run migrations 02/08/18 18:10
        

    }
}
