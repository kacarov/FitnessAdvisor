using System;
using App.Models.Enums;
using App.Models.UserInfo;
namespace App.Models.BodyFatCalculator
{
    public static class BodyFatCalculator
    {

       public static double Calculate(User user)
        {
            double calculations;
            double bodyFatPercentage = 0;
            
            if (user.Gender.Equals(GenderType.Male))
            {
                calculations = 1.0324 - (0.19077 * Math.Log10(user.Measurements.WaistSize - user.Measurements.NeckSize))
                   + (0.15456 * Math.Log10(user.Measurements.Height));
            }
            else if(user.Gender.Equals(GenderType.Female))
            {
                calculations = 1.29579 - (0.35004 * Math.Log10(user.Measurements.WaistSize + user.Measurements.HipsSize - user.Measurements.NeckSize))
                    + (0.22100 * Math.Log10(user.Measurements.Height));
            }
            else
            {
                throw new ArgumentException();
            }
               
               bodyFatPercentage = (495 / calculations) - 450;
               
            return bodyFatPercentage;
        }
    }
}
