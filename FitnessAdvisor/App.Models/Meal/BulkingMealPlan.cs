using System;

namespace App.Models.Meal
{
    public class BulkingMealPlan : MealPlan
    {
        public BulkingMealPlan(int caloricNeeds)
            : base(caloricNeeds)
        {
            this.CalculateMealPlan();
        }

        // Calculates protein, carbs and fats needs that the user need to consume per day.
        protected override void CalculateMealPlan()
        {
            double caloriesFromProtein = (25.0 / 100) * this.CaloricNeeds;
            double caloriesFromCarbs = (60.0 / 100) * this.CaloricNeeds;
            double caloriesFromFat = (15.0 / 100) * this.CaloricNeeds;

            base.GramsOfProtein = (int)(Math.Round(caloriesFromProtein, 0)) / 4;
            base.GramsOfCarbs = (int)(Math.Round(caloriesFromCarbs, 0)) / 4;
            base.GramsOfFats = (int)(Math.Round(caloriesFromFat, 0) / 9);
        }
    }
}
