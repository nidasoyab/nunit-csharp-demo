using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.CompilerServices;
using CSharpUnitTestChallenge.Library;
using CSharpUnitTestChallenge.Library.Validations;


namespace CSharpUnitTestChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter your first name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Please enter your last name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Please enter your date of birth (dd/mm/yyyy):");
            var dateOfBirth = Console.ReadLine();

            Console.WriteLine("Please enter your monthly budgeted cost for pet food:");
            var petFoodCost = Console.ReadLine();

            Console.WriteLine("Please enter the number of pets you own:");
            var numberOfPets = Console.ReadLine();

            Console.Clear();


            try
            {
                ValidateMonthlyBudget validateMonthlyBudget = new ValidateMonthlyBudget();

                var validationResult = validateMonthlyBudget.Validate(firstName, lastName, dateOfBirth, petFoodCost, numberOfPets);

                if (validationResult.Item1 == true)
                {

                    var monthlyBudget = validationResult.Item2.Adapt();

                    var finalReport = BuildReport(monthlyBudget);

                    Console.WriteLine(finalReport);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }


        }

        private static string BuildReport(MonthlyBudget monthlyBudget)
        {
            string finalReport = "";

            try
            {
                finalReport = "Welcome, " + monthlyBudget.FullName + ".";
                
                if (monthlyBudget.IsBirthday == true)
                {
                    finalReport = finalReport + " HAPPY BIRTHDAY!!!";
                }

                finalReport = finalReport + Environment.NewLine  + Environment.NewLine + "Your monthly cost per pet is: $ " + monthlyBudget.AvergeCostPerPet.ToString("#,##.00");

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message.ToString());
                return null;
            }

            return finalReport;
        }
    }
}
