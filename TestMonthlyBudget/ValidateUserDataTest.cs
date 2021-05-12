using CSharpUnitTestChallenge.Library;
using CSharpUnitTestChallenge.Library.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMonthlyBudget
{
    [TestClass]
    public class ValidateUserDataTest
    {
        private ValidateMonthlyBudget custData;
        public string exceptionMessage;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void MyTestInitiliaze()
        {
            if(custData==null)
            {
                custData = new ValidateMonthlyBudget();
            }
            
        }

        [TestMethod]
        public void ValidateInValidFirstName()
        {
            try
            {
                custData.Validate(ResourceFile.inValidFirstName, ResourceFile.validLastName, ResourceFile.validDOB,
                    ResourceFile.validPetFoodCost, ResourceFile.validNumberPets);
            }
            catch (Exception ex)
            {

                exceptionMessage = ex.Message;
            }
            Assert.AreEqual(exceptionMessage, "First Name cannot be less than 2 characters");
            
        }

        [TestMethod]
        public void ValidateLastName()
        {
            try
            {
                custData.Validate(ResourceFile.validFirstName, ResourceFile.inValidLastName, ResourceFile.validDOB,
                    ResourceFile.validPetFoodCost, ResourceFile.validNumberPets);
            }
            catch (Exception ex)
            {

                exceptionMessage = ex.Message;
            }
            Assert.AreEqual(exceptionMessage, "Last Name cannot be less than 2 characters");
        }

        [TestMethod]
        public void ValidateDOB()
        {
            try
            {
                custData.Validate(ResourceFile.validFirstName, ResourceFile.validLastName, ResourceFile.inValidDOB,
                    ResourceFile.validPetFoodCost, ResourceFile.validNumberPets);
            }
            catch (Exception ex)
            {

                exceptionMessage = ex.Message;
            }
            Assert.AreEqual(exceptionMessage, "Date Of Birth is not a valid date");
        }

        [TestMethod]
        public void ValidateLessDOB()
        {
            try
            {
                custData.Validate(ResourceFile.validFirstName, ResourceFile.validLastName, ResourceFile.lessInvalidDOB,
                    ResourceFile.validPetFoodCost, ResourceFile.validNumberPets);
            }
            catch (Exception ex)
            {

                exceptionMessage = ex.Message;
            }
            Assert.AreEqual(exceptionMessage, "You must be 18 years or older to use this application");
        }

        [TestMethod]
        public void ValidatePetFoodCost()
        {
            try
            {
                custData.Validate(ResourceFile.validFirstName, ResourceFile.validLastName, ResourceFile.validDOB,
                    ResourceFile.inValidPetFoodCost, ResourceFile.validNumberPets);
            }
            catch (Exception ex)
            {

                exceptionMessage = ex.Message;
            }
            Assert.AreEqual(exceptionMessage, "Pet Food Cost is not a valid number");
        }

        [TestMethod]
        public void ValidateNumberOfPets()
        {
            try
            {
                custData.Validate(ResourceFile.validFirstName, ResourceFile.validLastName, ResourceFile.validDOB,
                    ResourceFile.validPetFoodCost, ResourceFile.inValidNumberOFPets);
            }
            catch (Exception ex)
            {

                exceptionMessage = ex.Message;
            }
            Assert.AreEqual(exceptionMessage, "Number of pets is not a valid number");
        }
    }
}
