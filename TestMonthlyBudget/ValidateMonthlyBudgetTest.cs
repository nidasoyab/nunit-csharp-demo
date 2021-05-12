using CSharpUnitTestChallenge.Library;
using CSharpUnitTestChallenge.Library.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMonthlyBudget
{
    [TestClass]
    public class ValidateMonthlyBudgetTest
    {
        private ValidateMonthlyBudget custData;
        private Tuple<bool, MonthlyBudget> results;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void MyTestInitiliaze()
        {
            custData = new ValidateMonthlyBudget();
        }

        [TestMethod]
        public void VerifyUserVerifiesMonthlyBudget()
        {
            results = custData.Validate(ResourceFile.validFirstName, ResourceFile.validLastName, ResourceFile.validDOB,
                    ResourceFile.validPetFoodCost, ResourceFile.validNumberPets);
            Assert.IsTrue(results.Item1, "values are not loaded correctly");
           
            var monthlyBudget = results.Item2.Adapt();
            
            var finalReport = Report.BuildReport(monthlyBudget);

            Assert.AreEqual(finalReport, "Welcome, " + monthlyBudget.FullName + "." + Environment.NewLine + Environment.NewLine + "Your monthly cost per pet is: $ " + monthlyBudget.AvergeCostPerPet.ToString("#,##.00"));
        }

        [TestMethod]
        public void VerifyMonthlyBudgetForInValidPets()
        {
            string message = string.Empty;
            try
            {
                results = custData.Validate(ResourceFile.validFirstName, ResourceFile.validLastName, ResourceFile.validDOB,
                    ResourceFile.validPetFoodCost, ResourceFile.inValidNumberOFPets);
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            
            Assert.AreEqual(message, "Number of pets is not a valid number");

        }

        [TestMethod]
        public void VerifyMonthlyBudgetBirthday()
        {
            DateTime date = DateTime.Now;
            string dob = DateTime.Parse(string.Concat(date.Month.ToString(), "/", date.Day.ToString(), "/", "1987")).ToString();
            results = custData.Validate(ResourceFile.validFirstName, ResourceFile.validLastName, dob,
                    ResourceFile.validPetFoodCost, ResourceFile.validNumberPets);
            Assert.IsTrue(results.Item1, "values are not loaded correctly");

            var monthlyBudget = results.Item2.Adapt();

            var finalReport = Report.BuildReport(monthlyBudget);

            Assert.AreEqual(finalReport, "Welcome, " + monthlyBudget.FullName + "." + " HAPPY BIRTHDAY!!!" + Environment.NewLine + Environment.NewLine + "Your monthly cost per pet is: $ " + 
                monthlyBudget.AvergeCostPerPet.ToString("#,##.00"));

        }

    }
}
