using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecialRequirement>().HasData(
             new SpecialRequirement
             {
                 SpecialRequirementId = 1,
                 Name = "Disabilities",
                 ApplicationSpecRequirements = null
             });
            modelBuilder.Entity<SpecialRequirement>().HasData(
                new SpecialRequirement
                {
                    SpecialRequirementId = 2,
                    Name = "Illinessinfamily",
                    ApplicationSpecRequirements = null
                });

            modelBuilder.Entity<Municipality>().HasData(
                new Municipality
                {
                    MunicipalityId = 1,
                    Name = "Oslo"
                });

            modelBuilder.Entity<Municipality>().HasData(
                new Municipality
                {
                    MunicipalityId = 2,
                    Name = "Oslo2"
                });

            modelBuilder.Entity<WeekDay>().HasData(
                new WeekDay
                {
                    WeekId = 1,
                    Keyword = "M",
                    Day = "Monday"
                });
            modelBuilder.Entity<WeekDay>().HasData(
                new WeekDay
                {
                    WeekId = 2,
                    Keyword = "T",
                    Day = "Tuesday"
                });
            modelBuilder.Entity<WeekDay>().HasData(
                new WeekDay
                {
                    WeekId = 3,
                    Keyword = "W",
                    Day = "Wednesday"
                });
            modelBuilder.Entity<WeekDay>().HasData(
                new WeekDay
                {
                    WeekId = 4,
                    Keyword = "T",
                    Day = "Thursday"
                });
            modelBuilder.Entity<WeekDay>().HasData(
                new WeekDay
                {
                    WeekId = 5,
                    Keyword = "F",
                    Day = "Friday"
                });
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    NationalId = "11111111111",
                    Address = "oslo, Norway",
                    Email = "abc@xyz.com",
                    FirstLanguage = "Norway",
                    FirstName = "Arne",
                    LastName = "Legureett",
                    LevelOfSpoken = "Medium",
                    MaritalStatus = null,
                    PhoneNumber = 11111111,
                    //ChildApplications = null,
                    //FatherApplications = null,
                    //MotherApplications = null
                });
            modelBuilder.Entity<Person>().HasData(
           new Person
           {
               NationalId = "44444444444",
               Address = "oslo, Norway",
               Email = "martin@xyz.com",
               FirstLanguage = "Norway",
               FirstName = "Martin",
               LastName = "Legureett",
               LevelOfSpoken = "Low",
               MaritalStatus = null,
               PhoneNumber = 33333333,
                    //ChildApplications = null,
                    //FatherApplications = null,
                    //MotherApplications = null
                });
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    NationalId = "22222222222",
                    Address = "oslo, Norway",
                    Email = "abc@xyz.com",
                    FirstLanguage = "Norway",
                    FirstName = "Per",
                    LastName = "Legureett",
                    LevelOfSpoken = "Low",
                    MaritalStatus = "Married",
                    PhoneNumber = 22222222,
                    //ChildApplications = null,
                    //FatherApplications = null,
                    //MotherApplications = null
                });
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    NationalId = "33333333333",
                    Address = "oslo, Norway",
                    Email = "abc@xyz.com",
                    FirstLanguage = "Norway",
                    FirstName = "Marianna",
                    LastName = "Legureett",
                    LevelOfSpoken = "Low",
                    MaritalStatus = "Married",
                    PhoneNumber = 33333333,
                    //ChildApplications = null,
                    //FatherApplications = null,
                    //MotherApplications = null
                });

            modelBuilder.Entity<ApplicationSpecRequirement>().HasData(
                new ApplicationSpecRequirement
                {
                    ApplicationId = Guid.Parse("1A3B944E-3632-467B-A53A-206305310BAE"),
                    SpecialRequirementId = 1
                });

            modelBuilder.Entity<ApplicationSpecRequirement>().HasData(
                new ApplicationSpecRequirement
                {
                    ApplicationId = Guid.Parse("1A3B944E-3632-467B-A53A-206305310BAE"),
                    SpecialRequirementId = 2
                });

            modelBuilder.Entity<ApplicationKindergartenCoverage>().HasData(
                new ApplicationKindergartenCoverage
                {
                    ApplicationId = Guid.Parse("1A3B944E-3632-467B-A53A-206305310BAE"),
                    WeekType = "Even",
                    WeekId = 1
                });

            modelBuilder.Entity<ApplicationKindergartenCoverage>().HasData(
                new ApplicationKindergartenCoverage
                {
                    ApplicationId = Guid.Parse("1A3B944E-3632-467B-A53A-206305310BAE"),
                    WeekType = "Even",
                    WeekId = 3
                });

            modelBuilder.Entity<ApplicationKindergartenCoverage>().HasData(
                new ApplicationKindergartenCoverage
                {
                    ApplicationId = Guid.Parse("1A3B944E-3632-467B-A53A-206305310BAE"),
                    WeekType = "Odd",
                    WeekId = 2
                });

            modelBuilder.Entity<ApplicationKindergartenCoverage>().HasData(
                new ApplicationKindergartenCoverage
                {
                    ApplicationId = Guid.Parse("1A3B944E-3632-467B-A53A-206305310BAE"),
                    WeekType = "Odd",
                    WeekId = 4
                });

            modelBuilder.Entity<Application>().HasData(
                new Application
                {
                    ApplicationId = Guid.Parse("1A3B944E-3632-467B-A53A-206305310BAE"),
                    ApplicationStartDate = new DateTime(),
                    ApplicationSubmitDate = new DateTime(),
                    ChildId = "11111111111",
                    FatherId = "22222222222",
                    MotherId = "33333333333",
                    IsChooseDiffDays = true,
                    MunicipalityId = 1,
                    IsReducedFee = true,
                    KindergartenCoverage = 60,
                    Status = "Draft"
                });

            modelBuilder.Entity<Application>().HasData(
              new Application
              {
                  ApplicationId = Guid.Parse("e2f7997c-ba14-46d4-b417-aef06b64d33e"),
                  ApplicationStartDate = new DateTime(),
                  ApplicationSubmitDate = new DateTime(),
                  ChildId = "44444444444",
                  FatherId = "22222222222",
                  MotherId = "33333333333",
                  IsChooseDiffDays = true,
                  MunicipalityId = 1,
                  IsReducedFee = false,
                  KindergartenCoverage = 60,
                  Status = "Draft"
              });

            modelBuilder.Entity<ApplicationSpecRequirement>().HasData(
              new ApplicationSpecRequirement
              {
                  ApplicationId = Guid.Parse("e2f7997c-ba14-46d4-b417-aef06b64d33e"),
                  SpecialRequirementId = 1
              });

            modelBuilder.Entity<ApplicationKindergartenCoverage>().HasData(
                new ApplicationKindergartenCoverage
                {
                    ApplicationId = Guid.Parse("e2f7997c-ba14-46d4-b417-aef06b64d33e"),
                    WeekType = "Even",
                    WeekId = 2
                });

            modelBuilder.Entity<ApplicationKindergartenCoverage>().HasData(
                new ApplicationKindergartenCoverage
                {
                    ApplicationId = Guid.Parse("e2f7997c-ba14-46d4-b417-aef06b64d33e"),
                    WeekType = "Even",
                    WeekId = 4
                });

            modelBuilder.Entity<ApplicationKindergartenCoverage>().HasData(
                new ApplicationKindergartenCoverage
                {
                    ApplicationId = Guid.Parse("e2f7997c-ba14-46d4-b417-aef06b64d33e"),
                    WeekType = "Odd",
                    WeekId = 1
                });

            modelBuilder.Entity<ApplicationKindergartenCoverage>().HasData(
                new ApplicationKindergartenCoverage
                {
                    ApplicationId = Guid.Parse("e2f7997c-ba14-46d4-b417-aef06b64d33e"),
                    WeekType = "Odd",
                    WeekId = 3
                });
        }
    }
}
