using App.Models.BodyFatCalculator;
using App.Models.Enums;
using App.Models.UserInfo;
using System;

namespace App.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BioData bioData = new BioData(92,190,42,89,95);
            User user = new User("Martin", 23, GenderType.Male, bioData);
            
            double bf = BodyFatCalculator.Calculate(user);
           
            Console.WriteLine(bf);
        }
    }
}
