using App.Models.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.Contracts
{
    public interface ICalculatable
    {
         double CalculateBodyFat(User user);
        int CalculateCalories(User user);
    }
}
