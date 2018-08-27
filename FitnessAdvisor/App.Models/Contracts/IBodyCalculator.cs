namespace App.Models.Contracts
{
    public interface IBodyCalculator
    {
        double CalculateBodyFat(IUser user);

        int CalculateCalories(IUser user);
    }
}