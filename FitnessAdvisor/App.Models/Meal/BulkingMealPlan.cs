using System;

namespace App.Models.Meal
{
    public class BulkingMealPlan : MealPlan
    {
        public BulkingMealPlan(int caloricNeeds) : base(caloricNeeds)
        {
            double caloriesFromProtein = (25.0 / 100) * caloricNeeds;
            double caloriesFromCarbs = (60.0 / 100) * caloricNeeds;
            double caloriesFromFat = (15.0 / 100) * caloricNeeds;
            GramsOfProtein = (int)(Math.Round(caloriesFromProtein, 0))/4;
            GramsOfCarbs = (int)(Math.Round(caloriesFromCarbs, 0))/4;
            GramsOfFats = (int)(Math.Round(caloriesFromFat, 0)/9);
        }
        
    }
}
