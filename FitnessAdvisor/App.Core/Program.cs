using App.Models.Calculators;
using App.Models.Enums;
using App.Models.UserInfo;
using System;

namespace App.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BioData bioData = new BioData(23, GenderType.Female, 93,189,42,89,95);
            User user = new User("Martin", bioData);

            BodyCalculator bC = new BodyCalculator();
           
            Console.WriteLine(bC.CalculateBodyFat(user));
            Console.WriteLine(bC.CalculateCalories(user));
        }
    }
}
