using System;

namespace App.Models.Meal
{
    public class CuttingMealPlan : MealPlan
    {
        public CuttingMealPlan(int caloricNeeds) : base(caloricNeeds)
        {
            double caloriesFromProtein = (45.0 / 100) * caloricNeeds;
            double caloriesFromCarbs = (20.0 / 100) * caloricNeeds;
            double caloriesFromFat = (35.0 / 100) * caloricNeeds;
            GramsOfProtein = (int)(Math.Round(caloriesFromProtein, 0)) / 4;
            GramsOfCarbs = (int)(Math.Round(caloriesFromCarbs, 0)) / 4;
            GramsOfFats = (int)(Math.Round(caloriesFromFat, 0) / 9);
        }
    }
}
