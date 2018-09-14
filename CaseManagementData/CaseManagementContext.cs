using CaseManagementData.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseManagementData
{
    public class CaseManagementContext : DbContext

    {
        
        public CaseManagementContext(DbContextOptions options) : base(options) { }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CreditScore> CreditScores { get; set; }
        public DbSet<IncomeType> IncomeTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<User> Users { get; set; }
      
        // table per hierarcxhy for assets\
        // service l;ayer handles all of the interaction between data in database, retrieve sets of data, imnstances, CRUD operations 
        //
       
    }


}
