using System;
using System.Data.Common;
using System.Linq.Expressions;

namespace CSharpUnitTestChallenge.Library
{
    public class MonthlyBudget
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public int NumberOfPets { get; set; }

        public double PetFoodCost { get; set; }

        public string FullName { get; set; }

        public Boolean IsBirthday { get; set; }

        public double AvergeCostPerPet { get; set; }

        public  MonthlyBudget Adapt()
        {
            var result = this;

            result.FullName = this.FirstName.Trim() + " " + this.LastName.Trim();

            if (result.DateOfBirth.Day == DateTime.Now.Day && result.DateOfBirth.Month == DateTime.Now.Month)
            {
                result.IsBirthday = true;
            }
            else
            {
                result.IsBirthday = false;
            }

            result.AvergeCostPerPet = result.PetFoodCost / result.NumberOfPets;

            return result;
        }
    }

}

