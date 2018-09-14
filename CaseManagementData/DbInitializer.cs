using CaseManagementData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseManagementData
{
    public static class DbInitializer
    {

        public static void Initialize(CaseManagementContext context )
        {
            context.Database.EnsureCreated();

            if (!context.Statuses.Any())
            {
                var statuses = new Status[]
                 {
                    new Status{Name="Created"},
                    new Status{Name="In Progress"},
                    new Status{Name="All Outcomes Received"},

                    new Status{Name="Declined"},
                    new Status{Name="Submitted"},
                    new Status{Name="Declined-Scoring"},
                    new Status{Name="Declined-Affordability"},
                    new Status{Name="Full Grant"},

                 };
                foreach (Status s in statuses)
                {
                    context.Statuses.Add(s);
                }
                context.SaveChanges();
            }

            if (!context.CreditScores.Any())
            {
                var CreditScores = new CreditScore[]
                {
                new CreditScore{Name="Average"},
                new CreditScore { Name = "Bad" },
                new CreditScore{Name= "Excellent"},
                new CreditScore{Name= "Good"},

                };
                foreach (CreditScore c in CreditScores)
                {
                    context.CreditScores.Add(c);
                }
                context.SaveChanges();
            }

            if (!context.IncomeTypes.Any())
            {
                var IncomeTypes = new IncomeType[]
                {
                    new IncomeType{Name = "Low"},
                    new IncomeType{Name = "Middle"},
                    new IncomeType{Name = "High"},
                };
                foreach (IncomeType i in IncomeTypes)
                {
                    context.IncomeTypes.Add(i);

                }
                context.SaveChanges();
            }

            if (!context.Positions.Any())
            {
                var Position = new Position[]
                {
                    new Position{Description = "Sales Admin"},
                    new Position{Description = "Sales Admin manager"},
                };
                foreach (Position i in Position)
                {
                    context.Positions.Add(i);

                }
                context.SaveChanges();
            }

            if (!context.Banks.Any())
            {
                var Banks = new Bank[]
                {
                    new Bank{Name = "ABSA"},
                    new Bank{Name = "Standard Bank SA"},
                    new Bank{Name = "FNB"},
                    new Bank{Name = "Nedbank"},
                };
                foreach (Bank b in Banks)
                {
                    context.Banks.Add(b);

                }
                context.SaveChanges();
            }


            if (!context.Applicants.Any())
            {
                var Applicants = new Applicant[]
                {
                   new Applicant{IdNumber="9810015007086", FirstName="Emmanuel", LastName="Dube", Income=340000, Credit = 400},
                   new Applicant{IdNumber="7812166007086", FirstName="Busisiwe", LastName="Mbatha", Income=80000, Credit = 800},
                   new Applicant{IdNumber="8812105016089", FirstName="Tumelo", LastName="Malalane", Income=340000, Credit = 699},
                   new Applicant{IdNumber="9712265016083", FirstName="Sphamandla", LastName="Motshoeni", Income=50000, Credit = 210},
                   new Applicant{IdNumber="7410055098087", FirstName="Nkosinathi", LastName="Nkhomo", Income=40000, Credit = 356},
                   new Applicant{IdNumber="7311166057086", FirstName="Sabrina", LastName="Anthony", Income=35500, Credit = 609},
                   new Applicant{IdNumber="9702076006986", FirstName="Chandre", LastName="Kubie", Income=23000, Credit = 899},
                   new Applicant{IdNumber="6801015800084", FirstName="John", LastName="Adams", Income=2500, Credit = 320},
                   new Applicant{IdNumber="9706134800082", FirstName="Amy", LastName="Brammall", Income=56000, Credit = 100},
                   new Applicant{IdNumber="9602075019086", FirstName="Jessica", LastName="Blue", Income=230000, Credit = 564},
                   new Applicant{IdNumber="7509095000082", FirstName="Dan", LastName="Green", Income=27000, Credit = 321},
                   new Applicant{IdNumber="7412066060089", FirstName="Ben", LastName="Cloete", Income=29000, Credit = 900},
                   new Applicant{IdNumber="9201015007086", FirstName="Billy", LastName="Bulb", Income=3400000, Credit = 679},
                   new Applicant{IdNumber="8812016007082", FirstName="Ben", LastName="Pukulski", Income=800000, Credit = 546},
                   new Applicant{IdNumber="9703235016089", FirstName="Bianca", LastName="Gillies", Income=40000, Credit = 985},
                   new Applicant{IdNumber="7702176007084", FirstName="Iman", LastName="Isaacs", Income=12000, Credit = 590},
                   new Applicant{IdNumber="7410055098087", FirstName="Michael", LastName="Mabaso", Income=60000, Credit = 505},
                   new Applicant{IdNumber="7311166057086", FirstName="Sue", LastName="Naidoo", Income=43250, Credit = 134},
                   new Applicant{IdNumber="7402176006986", FirstName="Jolene", LastName="Grey", Income=57000, Credit = 452},
                   new Applicant{IdNumber="6801015800084", FirstName="Megan", LastName="Van de Berg", Income=150000, Credit = 546},
                   new Applicant{IdNumber="6911084800082", FirstName="Madeleine", LastName="Willemse", Income=21000, Credit = 689},
                   new Applicant{IdNumber="9602075019086", FirstName="Jess", LastName="Green", Income=230000, Credit = 987},
                   new Applicant{IdNumber="7509095000082", FirstName="Nick", LastName="Nxumalo", Income=410000, Credit = 500},
                   new Applicant{IdNumber="7509066060087", FirstName="Itumeleng", LastName="Mehlape", Income=30000, Credit = 900}
                };
                foreach (Applicant i in Applicants)
                {
                    context.Applicants.Add(i);

                }
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var Users = new User[]
                {
                    new User{Email="shaun.marioa@gmail.com", FirstName="Shaun", LastName="Pollock", Password="shaun"},
                    new User{Email="tristan.killt@gmail.com", FirstName="Tristan", LastName="Nickle",Password="tristan"},
                    new User{Email="zed.springfield@gmail.com", FirstName="Zed", LastName="Springfield",Password="zedspring"},
                    new User{Email="megan.vandeberg7@gmail.com", FirstName="Megan", LastName="Van de Berg",Password="megan"},
                    new User{Email="ben.mulligan@gmail.com", FirstName="Ben", LastName="Mulligan",Password="benmul"},
                    new User{Email="john.pierce05@gmail.com", FirstName="John", LastName="Pierce",Password="john"},
                    new User{Email="jess.blue09@gmail.com", FirstName="Jess", LastName="Blue",Password="jess"}

                };

                foreach (User i in Users)
                {
                    context.Users.Add(i);

                }
                context.SaveChanges();
            }

            if (!context.Cases.Any())
            {

                Applicant[] applicants = new Applicant[3];


                applicants[0] = context.Applicants
                   .Include(applicant => applicant.CreditScore)
                   .Include(applicant => applicant.IncomeType)
                   .FirstOrDefault(applicant => applicant.IdNumber == "7410055098087");

                applicants[1] = context.Applicants
                   .Include(applicant => applicant.CreditScore)
                   .Include(applicant => applicant.IncomeType)
                   .FirstOrDefault(applicant => applicant.IdNumber == "9810015007086");

           

                User tristan = context.Users.FirstOrDefault(u => u.FirstName == "Tristan");

                var Cases = new Case[]
                {
                    new Case{LoanAmount=600000, Applicant= applicants[0], DateCreated= DateTime.Now, OfferToPurchaseDoc = true, Status = context.Statuses.FirstOrDefault(s=>s.Name=="Created"), User =tristan},
                    new Case{LoanAmount=900000, Applicant= applicants[1], DateCreated= DateTime.Now, OfferToPurchaseDoc = true, Status = context.Statuses.FirstOrDefault(s=>s.Name=="In Progress"), User =tristan}


                };

                foreach (Case i in Cases)
                {
                    context.Cases.Add(i);

                }
                context.SaveChanges();
            }


            if (!context.Submissions.Any())
            {

                Applicant applicantInprogress = context.Applicants.FirstOrDefault(a => a.IdNumber == "9810015007086");
                Bank bank = context.Banks.FirstOrDefault(b => b.Name == "ABSA");
                Case caseApplicant = context.Cases.FirstOrDefault(c => c.Applicant == applicantInprogress);
                Status startStatus = context.Statuses.FirstOrDefault(s => s.Name == "Submitted");
                var Submissions = new Submission[]
                {
                    new Submission{ Bank=bank, BankResponseDateTime=DateTime.Now, Case = caseApplicant, BankResponseDoc= true, DateSubmitted= DateTime.Now, Status = startStatus  }

                };

                foreach (Submission i in Submissions)
                {
                    context.Submissions.Add(i);

                }
                context.SaveChanges();
            }




        }


    }
}
