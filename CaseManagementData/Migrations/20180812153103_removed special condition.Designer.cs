﻿// <auto-generated />
using System;
using CaseManagementData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaseManagementData.Migrations
{
    [DbContext(typeof(CaseManagementContext))]
    [Migration("20180812153103_removed special condition")]
    partial class removedspecialcondition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaseManagementData.Models.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cellphone");

                    b.Property<int>("Credit");

                    b.Property<int?>("CreditScoreId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("IdNumber");

                    b.Property<decimal>("Income");

                    b.Property<int?>("IncomeTypeId");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("CreditScoreId");

                    b.HasIndex("IncomeTypeId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("CaseManagementData.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("CaseManagementData.Models.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicantId");

                    b.Property<bool>("CaseSlaBreach");

                    b.Property<DateTime>("DateCreated");

                    b.Property<decimal>("LoanAmount");

                    b.Property<bool>("OfferToPurchaseDoc");

                    b.Property<int?>("StatusId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("CaseManagementData.Models.CreditScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CreditScores");
                });

            modelBuilder.Entity("CaseManagementData.Models.IncomeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("IncomeTypes");
                });

            modelBuilder.Entity("CaseManagementData.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("CaseManagementData.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("CaseManagementData.Models.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BankId");

                    b.Property<DateTime>("BankResponseDateTime");

                    b.Property<bool>("BankResponseDoc");

                    b.Property<int?>("CaseId");

                    b.Property<DateTime>("DateSubmitted");

                    b.Property<bool>("IsAccepted");

                    b.Property<decimal>("OfferedAmount");

                    b.Property<decimal>("OfferedInterestRate");

                    b.Property<decimal>("OfferedPeriod");

                    b.Property<int?>("StatusId");

                    b.Property<bool>("SubmissionSlaBreach");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CaseId");

                    b.HasIndex("StatusId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("CaseManagementData.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int?>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CaseManagementData.Models.Applicant", b =>
                {
                    b.HasOne("CaseManagementData.Models.CreditScore", "CreditScore")
                        .WithMany()
                        .HasForeignKey("CreditScoreId");

                    b.HasOne("CaseManagementData.Models.IncomeType", "IncomeType")
                        .WithMany()
                        .HasForeignKey("IncomeTypeId");
                });

            modelBuilder.Entity("CaseManagementData.Models.Case", b =>
                {
                    b.HasOne("CaseManagementData.Models.Applicant", "Applicant")
                        .WithMany("Cases")
                        .HasForeignKey("ApplicantId");

                    b.HasOne("CaseManagementData.Models.Status", "Status")
                        .WithMany("cases")
                        .HasForeignKey("StatusId");

                    b.HasOne("CaseManagementData.Models.User", "User")
                        .WithMany("Cases")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CaseManagementData.Models.Submission", b =>
                {
                    b.HasOne("CaseManagementData.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("CaseManagementData.Models.Case", "Case")
                        .WithMany("Submissions")
                        .HasForeignKey("CaseId");

                    b.HasOne("CaseManagementData.Models.Status", "Status")
                        .WithMany("submissions")
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("CaseManagementData.Models.User", b =>
                {
                    b.HasOne("CaseManagementData.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
                });
#pragma warning restore 612, 618
        }
    }
}
