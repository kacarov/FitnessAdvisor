using App.Models.Contracts;
using System;
using System.Text;

namespace App.Models.Meal
{
    public abstract class MealPlan : IMealPlan
    {
        private int caloricNeeds;
        private int gramsOfProtein;
        private int gramsOfCarbs;
        private int gramsOfFats;

        protected MealPlan(int caloricNeeds)
        {
            this.CaloricNeeds = caloricNeeds;
        }

        public int GramsOfProtein
        {
            get
            {
                return this.gramsOfProtein;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Grams of protein cannot be null.");
                }
                this.gramsOfProtein = value;
            }
        }

        public int GramsOfCarbs
        {
            get
            {
                return this.gramsOfCarbs;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Grams of carbs cannot be null.");
                }
                this.gramsOfCarbs = value;
            }
        }

        public int GramsOfFats
        {
            get
            {
                return this.gramsOfFats;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Grams of fat cannot be null.");
                }
                this.gramsOfFats = value;
            }
        }

        public int CaloricNeeds
        {
            get
            {
                return this.caloricNeeds;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Calorie needs cannot be negative.");
                }
                caloricNeeds = value;
            }
        }

        protected abstract void CalculateMealPlan();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("----> Caloric needs: " + this.CaloricNeeds);
            builder.AppendLine("----> Protein: " + this.GramsOfProtein + "g");
            builder.AppendLine("----> Carbs: " + this.GramsOfCarbs + "g");
            builder.AppendLine("----> Fats: " + this.GramsOfFats + "g");

            return builder.ToString();
        }
    }
}
