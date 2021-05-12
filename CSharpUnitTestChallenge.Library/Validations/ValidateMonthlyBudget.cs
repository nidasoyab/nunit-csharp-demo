using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace CSharpUnitTestChallenge.Library.Validations
{
    public class ValidateMonthlyBudget
    {
        public Tuple<bool, MonthlyBudget> Validate(string firstName, string lastName, string dateOfBirth, string petFoodCost, string numberOfPets)
        {
            bool isValid = false;
            MonthlyBudget monthlyBudget = new MonthlyBudget();

            //Begin validations:

            if (firstName.Length < 2)
            {
                throw new Exception("First Name cannot be less than 2 characters");
            }

            if (lastName.Length < 2)
            {
                throw new Exception("Last Name cannot be less than 2 characters");
            }

            if (DateTime.TryParse(dateOfBirth, out DateTime dob) == false)
            {
                throw new Exception("Date Of Birth is not a valid date");
            }

            if (DateAndTime.DateDiff( DateInterval.Year, dob, DateTime.Now) < 18)
            {
                throw new Exception("You must be 18 years or older to use this application");
            }

            if (double.TryParse(petFoodCost, out double pfc) == false)
            {
                throw new Exception("Pet Food Cost is not a valid number");
            }

            if (int.TryParse(numberOfPets, out int nop) == false)
            {
                throw new Exception("Number of pets is not a valid number");
            }

            //All validations past, continue with object property assignment:
            
            isValid = true;
            
            monthlyBudget.FirstName = firstName;
            
            monthlyBudget.LastName = lastName;
            
            monthlyBudget.DateOfBirth = dob;
            
            monthlyBudget.PetFoodCost = pfc;
            
            monthlyBudget.NumberOfPets = nop;

            return Tuple.Create(isValid, monthlyBudget);
        }


    }
}
