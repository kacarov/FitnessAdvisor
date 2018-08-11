using App.Models.Calculators;
using App.Models.Contracts;
using App.Models.Enums;
using App.Models.GeneralPurpose;
using App.Models.Meal;
using App.Models.Supplements;
using App.Models.UserInfo;
using System;

namespace App.Core
{
    class Program
    {
        static void Main(string[] args)
        {

            BioData bioData = new BioData(23, GenderType.Female, 93, 189, 42, 89, 95);


            BodyCalculator bC = new BodyCalculator();
            User user = new User("Martin", bioData);
            Bulk goal = new Bulk(93, 14, bC.CalculateCalories(user));
            user.Goal = goal;
        
            
            Supplement supplement = new Supplement("Amix", "Fusion", Category.Protein, 70, "...");
          
           Maintain maintain = new Maintain(94, 14, bC.CalculateCalories(user));
            user.Goal = maintain;
           
           

            Cutting cut = new Cutting(94, 14, bC.CalculateCalories(user));
            user.Goal = cut;
            user.Goal.AddSupplement(supplement);
          
            Console.WriteLine(user.Goal.ToString());

            
        }
    }
}
