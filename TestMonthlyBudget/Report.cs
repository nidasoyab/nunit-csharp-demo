using CSharpUnitTestChallenge.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMonthlyBudget
{
    public class Report
    {
        public static string BuildReport(MonthlyBudget monthlyBudget)
        {
            string finalReport = "";

            try
            {
                finalReport = "Welcome, " + monthlyBudget.FullName + ".";

                if (monthlyBudget.IsBirthday == true)
                {
                    finalReport = finalReport + " HAPPY BIRTHDAY!!!";
                }

                finalReport = finalReport + Environment.NewLine + Environment.NewLine + "Your monthly cost per pet is: $ " + monthlyBudget.AvergeCostPerPet.ToString("#,##.00");

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
