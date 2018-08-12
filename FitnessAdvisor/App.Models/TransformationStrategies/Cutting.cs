using App.Models.Meal;
using App.Models.Training;
using App.Models.TransformationStrategies;

namespace App.Models.GeneralPurpose
{
    public class Cutting : BodyTransformationGoalAbstract
    {
        public Cutting(double currentWeight, double currentFatPercent, int caloricNeeds)
            : base(caloricNeeds - 1000, currentWeight - 5, currentWeight - 3, currentFatPercent - 3, currentFatPercent)
        {

            string weightLiftTip = "You must be lifting otherwise you will certainly lose muscle, that is a given. Lifting\n" +
                                   "will send signals to your body instructing it to build muscle. Although you won't be\n" +
                                   "building any muscle on low calories, this makes your body less likely for it to breakdown\n" +
                                   "muscle tissue that you already have. Lifting ensures that your body realizes that the muscle\n" +
                                   "that is there is important!\n\n" +
                                   "Use lifting routines which you have made gains on while building muscle.If you were making gains\n" +
                                   "in muscle mass, this is an indication that your body responds well to this type of stimulus; stic\n" +
                                   "to what works for you.\n\n" +
                                   "For example, if you get great gains using heavy weights to build muscle, then use heavy weights while\n" +
                                   "you are losing fat.If you get great gains using HST, periodization, high volume, low volume, etc.then\n" +
                                   "use those techniques while you are losing fat.\n\n" +
                                   "Lifting sessions are focused, effective and brief(less than 60 minutes). It is trivial to overwork your\n" +
                                   "body, so instead keep the mindset of get in, make it effective and get out (and eat!).\n\n" +
                                   "You should be aware of the increased potential for overtraining due to the low calorie diet.On lower\n" +
                                   "calories your recovery will be compromised and therefore you will not be able to push your body to the\n" +
                                   "extent that you may in the off season.";


            string cardioLiftTip = "Cardio may suck, but it is a powerful tool at your disposal to aid in fat loss. Cardio is great for\n" +
                                   "creating an additional energy deficit in your metabolism without having to eat less food.\n\n" +
                                   "For example, burning 200 Calories doing cardio will allow you to eat another 200 Calories(50 grams)\n" +
                                   "of muscle - sparing protein while still maintaining the same caloric deficit.There is plenty of\n" +
                                   "dispute on how and when to do cardio(upon waking, pre - lifting, post - lifting, on an empty stomach, etc.)\n" +
                                   "We have found the best results when treating cardio session like a lifting session. You will do it on days\n" +
                                   "when you are not lifting(or 6 + hours away from a lifting session).You will make sure to eat enough calories\n" +
                                   "both before and after cardio.";

            base.TrainingType = new TrainingType("Training tips while cutting", weightLiftTip, cardioLiftTip);
            base.MealPlan = new CuttingMealPlan(caloricNeeds - 1000);
        }
    }
}
