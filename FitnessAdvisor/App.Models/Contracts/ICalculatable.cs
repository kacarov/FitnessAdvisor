using App.Models.UserInfo;

namespace App.Models.Contracts
{
    public interface ICalculatable
    {
        double CalculateBodyFat(User user);

        int CalculateCalories(User user);
    }
}
