using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaseManagementData;
using CaseManagementData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    public class ApplicantService : IApplicant
    {
       
        private CaseManagementContext _context;


        public ApplicantService(CaseManagementContext context)
        {
            _context = context;
        }



        public void Add(Applicant newApplicant)
        {
            // set income types
            if(newApplicant.Income > 0 && newApplicant.Income < 300000)
            {
                var incomeType = _context.IncomeTypes.Where(it => it.Name == "LOW").FirstOrDefault();
                newApplicant.IncomeType = (IncomeType) incomeType;
            }
            else if(newApplicant.Income >= 300000 && newApplicant.Income < 600000)
            {
                var incomeType = _context.IncomeTypes.Where(it => it.Name == "Middle").FirstOrDefault();

                newApplicant.IncomeType = (IncomeType)incomeType;
            }
            else
            {
                var incomeType = _context.IncomeTypes.Where(it => it.Name == "High").FirstOrDefault();
                newApplicant.IncomeType = (IncomeType)incomeType;
            }

            // Set credit types

            if(newApplicant.Credit > 0 && newApplicant.Credit <= 550)
            {
                // bad
                newApplicant.CreditScore = _context.CreditScores.Where(cs => cs.Name == "Bad").FirstOrDefault();
            }
            else if(newApplicant.Credit > 550 && newApplicant.Credit <= 699)
            {
                //poor and fair
                newApplicant.CreditScore = _context.CreditScores.Where(cs => cs.Name == "Average").FirstOrDefault();
            }
            else
            {
                newApplicant.CreditScore = _context.CreditScores.Where(cs => cs.Name == "Good").FirstOrDefault();
            }
            _context.Add(newApplicant);
            _context.SaveChanges();
        }

        public Applicant Get(int id)
        {
            return  _context.Applicants
                  .Include(applicant => applicant.CreditScore)
                  .Include(applicant => applicant.IncomeType)
                  .FirstOrDefault(applicant => applicant.Id == id);

            // by using include we include that data in the reuslts 
        }

        public IEnumerable<Applicant> GetAll()
        {
            // get applicant for specifc  user 

            return _context.Applicants
            .Include(a => a.IncomeType)
            .Include(a => a.CreditScore)
            .OrderByDescending(a => a.LastName)
            ;
            

            
        }

        public IEnumerable<Case> GetCases(int applicantId)
        {
            return _context.Cases
            .Include(a => a.Applicant)
            .Include(c => c.Status)
            .Include(u => u.User)
            .Where(c => c.Applicant.Id == applicantId);
        }

        public IEnumerable<Applicant> SearchApplicant(string name)
        {

            return _context.Applicants

            .Include(a => a.IncomeType)
            .Include(a => a.CreditScore)
            .Where(a => a.FirstName.Contains(name));
            
            

        }


    }
}
