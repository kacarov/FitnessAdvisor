using App.Models.Contracts;
using App.Models.Enums;
using App.Models.UserInfo;
using System;
// CHECK THE VALIDATIONS
namespace App.Models.Calculators
{
    public class BodyCalculator : ICalculatable
    {
        //TODO static or singleton 
        public BodyCalculator()
        {
        }

        public double CalculateBodyFat(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }
            double calculations = 0;
            double bodyFatPercentage = 0;

            if (user.BioData.Gender.Equals(GenderType.Male))
            {
                calculations = 1.0324 - (0.19077 * Math.Log10(user.BioData.WaistSize - user.BioData.NeckSize))
                   + (0.15456 * Math.Log10(user.BioData.Height));
            }
            if (user.BioData.Gender.Equals(GenderType.Female))
            {
                calculations = 1.29579 - (0.35004 * Math.Log10(user.BioData.WaistSize + user.BioData.HipsSize - user.BioData.NeckSize))
                    + (0.22100 * Math.Log10(user.BioData.Height));
            }

            bodyFatPercentage = (495 / calculations) - 450;

            return bodyFatPercentage;
        }

        public int CalculateCalories(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }
            int calories = 0;
            if (user.BioData.Gender.Equals(GenderType.Male))
            {
                calories = Convert.ToInt32((10 * user.BioData.Weight + 6.25 * user.BioData.Height - 5 * user.BioData.Age + 5) * 1.55);
            }
            if (user.BioData.Gender.Equals(GenderType.Female))
            {
                calories = Convert.ToInt32((10 * user.BioData.Weight + 6.25 * user.BioData.Height - 5 * user.BioData.Age - 161) * 1.55);
            }

            return calories;
        }
    }
}
