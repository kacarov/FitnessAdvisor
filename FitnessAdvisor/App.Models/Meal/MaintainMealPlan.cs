using System;

namespace App.Models.Meal
{
    public class MaintainMealPlan : MealPlan
    {
        public MaintainMealPlan(int caloricNeeds)
            : base(caloricNeeds)
        {
            this.CalculateMealPlan();
        }

        protected override void CalculateMealPlan()
        {
            double caloriesFromProtein = (35.0 / 100) * this.CaloricNeeds;
            double caloriesFromCarbs = (40.0 / 100) * this.CaloricNeeds;
            double caloriesFromFat = (25.0 / 100) * this.CaloricNeeds;

            base.GramsOfProtein = (int)(Math.Round(caloriesFromProtein, 0)) / 4;
            base.GramsOfCarbs = (int)(Math.Round(caloriesFromCarbs, 0)) / 4;
            base.GramsOfFats = (int)(Math.Round(caloriesFromFat, 0) / 9);
        }
    }
}
