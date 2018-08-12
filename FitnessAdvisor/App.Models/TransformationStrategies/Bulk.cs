using App.Models.Meal;
using App.Models.Training;
using App.Models.TransformationStrategies;

namespace App.Models.GeneralPurpose
{
    public class Bulk : BodyTransformationGoalAbstract
    {
        private const string weightLiftTip = "Most people have the mentality that more is better. This is not the case with training.\n" +
                                   "Most of the time the people who have that mindset are overtraining and in turn minimizing their gains.\n" +
                                   "Depending on your exercise level, you could train smartly with 3-6 days in the gym.\n\n" +
                                   "You want to keep your workouts short but intense.This means that you should ideally\n" +
                                   "keep your workouts to less than one hour. Anything more and you are lowering your natural\n" +
                                   "testosterone levels, which you don't want to do. The key is to experiment and find out what\n" +
                                   "training style works best for your body.\n\n" +
                                   "Some people respond well to lower rep sets while others find higher reps sets are the way to go.\n" +
                                   "Some people can get away with a low number of sets while some people need to complete many sets\n" +
                                   "to get results.I would actually recommend starting with lower sets, evaluating your progress,\n" +
                                   "and adjusting it accordingly.\n\n" +
                                   "If you find you aren't growing with the number of sets you are doing, gradually increase\n" +
                                   "the sets and see how you respond to that. When it comes down to it, there really is no one\n" +
                                   "way to train. Everyone is different. The fun part is trying new things to see what works best for you.\n" +
                                   "Keep training hard and never be afraid to switch things up.";

        private const string cardioLiftTip = "This one isn't rocket science; you don't need a PhD to understand. Obviously when you\n" +
                                "do cardio, you use up fuel(calories). Calories are what you need to grow.You take away\n" +
                                "calories, you take away gains.Now I'm not saying to stop cardio altogether, because you\n" +
                                "don't need to.\n\n" +
                                "Cardio is actually a good way to keep from putting on body fat during a bulking phase\n" +
                                "and an excellent way to keep the heart healthy.\n\n" +
                                "Cardio also increases your appetite so you will be able to down some extra calories to\n" +
                                "make up for the loss you experienced during your workout.You can get away with doing\n" +
                                "some low - intensity cardio without losing lean mass gains, so do not be afraid to do\n" +
                                "cardio while bulking.";


        public Bulk(double currentWeight, double currentFatPercent, int caloricNeeds)
            : base(caloricNeeds + 1000, currentWeight + 3, currentWeight + 5, currentFatPercent, currentFatPercent + 2)
        {
            base.TrainingType = new TrainingType("Training tips while bulking", weightLiftTip, cardioLiftTip);
            base.MealPlan = new BulkingMealPlan(caloricNeeds + 1000);
        }
    }
}
