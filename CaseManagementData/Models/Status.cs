using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaseManagementData.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Case> cases { get; set; }
        public IEnumerable<Submission> submissions { get; set; }

    }
}
