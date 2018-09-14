using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaseManagementData.Models
{
    public class IncomeType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public string Description { get; set; }

    }
}
