using App.Models.Meal;
using App.Models.Training;
using App.Models.TransformationStrategies;

namespace App.Models.GeneralPurpose
{
    //Sets user's goal, training type and meal plan.
    public class Maintain : BodyTransformationGoalAbstract
    {
       /* private const string weightLiftTip = "As far as training goes, much like your eating, it doesn't have to be as regimented or rigorous.\n" +
                               "The biggest concept that we want to push and for people to understand is that you won't lose muscle\n" +
                               "overnight, especially if you keep training. Training, however, doesn't have to be as intense as it used to be.\n\n" +
                               "If you were used to going to the gym five times a week, hitting every body part with twelve to fifteen sets,\n" +
                               "try going only three times a week and doing a full body routine with about half as many sets and less intensity\n" +
                               "as you used to. You should also incorporate higher rep training in the twelve to twenty range.\n\n" +
                               "Training with higher repetitions will leave you with a sick pump, and will really demonstrate just how big you\n" +
                               "really are when your muscles are engorged with blood.You don't want to use heavy weights closer to your one rep\n" +
                               "max for as many sets as you used to, no longer is your goal to break down muscles to build them bigger.";

        private const string cardioLiftTip = "Since you are at the point where you are satisfied with the amount of muscle you have, you can use this time to\n" +
                               "train a different system of your body - your cardiovascular system. Excess cardio will impede on muscle gains, but\n" +
                               "now is a great time to really focus on it since you don't want to add muscle.\n\n" +
                               "You can drop some body fat, which will help you look better with your shirt off, and reap the benefits of improved\n" +
                               "cardiovascular conditioning!\n\n" +
                               "Don't be afraid to jog on the treadmill a couple days out of the week, granted you are still eating properly, albeit\n" +
                               "less, you should be able to improve your conditioning and look much better! Hey, if you no longer want to train to add\n" +
                               "mass, compensate elsewhere and improve a different aspect of your health!";

    */
        public Maintain(double currentWeight, double currentFatPercent, int caloricNeeds)
            : base(currentWeight - 0.5, currentWeight + 0.5, currentFatPercent - 0.5, currentFatPercent + 0.5)
        {
            base.TrainingType = new TrainingType("Training tips while maintaining",
                TrainingStrategyConstants.MaintainWeightLiftTip,
                TrainingStrategyConstants.CuttingCardioLiftTip);
            base.MealPlan = new MaintainMealPlan(caloricNeeds);
        }
    }
}
