using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApi.Data.Models;

namespace TaskApi.Data
{
    public static class SeedDbContext
    {
        public static void SeedData(TaskApiDbContext dbContext)
        {
            if (!dbContext.Companies.Any())
            {
                //1
                dbContext.Companies.Add(new Company()
                {
                    Name = "Microsoft",
                    CreationDate = new DateTime(4),
                    Offices = new List<Office>
                {
                    new Office
                    {
                        Country = "Germany",
                        City = "karlsruhe",
                        Street = "Strasse",
                        StreetNumber = 12,
                        Headquarters = true,
                    },
                     new Office
                    {
                        Country = "Bulgaria",
                        City = "Plovdiv",
                        Street = "UlitsaAilyak",
                        StreetNumber = 12,
                        Headquarters = false,
                    },
                },
                    Employees = new List<Employee>
                {
                    new Employee
                    {
                        ExperienceLevel = EmployeeExperienceLevel.Junior,
                        FirstName = "Adam",
                        LastName = "Barnett",
                        Salary = 150000,
                        StartingDate = new DateTime(2002, 05, 21),
                        VacationDays = 300,
                    },
                    new Employee
                    {
                        ExperienceLevel = EmployeeExperienceLevel.Senior,
                        FirstName = "Marc",
                        LastName = "Blank",
                        Salary = 640000,
                        StartingDate = new DateTime(1975, 04, 04),
                        VacationDays = 30,
                    }
                },
                });
                //2
                dbContext.Companies.Add(new Company()
                {
                    Name = "Google",
                    CreationDate = new DateTime(1998, 09, 04),
                    Offices = new List<Office>
                {
                    new Office
                    {
                        Country = "England",
                        City = "Bath",
                        Street = "Street",
                        StreetNumber = 1,
                        Headquarters = true,
                    },
                     new Office
                    {
                        Country = "Bulgaria",
                        City = "Sofia",
                        Street = "Ulitsa",
                        StreetNumber = 56,
                        Headquarters = false,
                    },
                },
                    Employees = new List<Employee>
                {
                    new Employee
                    {
                        ExperienceLevel = EmployeeExperienceLevel.Mid,
                        FirstName = "Steve",
                        LastName = "Chen",
                        Salary = 250000,
                        StartingDate = new DateTime(2002, 05, 21),
                        VacationDays = 30,
                    },
                    new Employee
                    {
                        ExperienceLevel = EmployeeExperienceLevel.Senior,
                        FirstName = "Matt",
                        LastName = "Cutts",
                        Salary = 690000,
                        StartingDate = new DateTime(2008, 07, 28),
                        VacationDays = 30,
                    }
                }

                });
            }
            dbContext.SaveChanges();
        }
    }
}
