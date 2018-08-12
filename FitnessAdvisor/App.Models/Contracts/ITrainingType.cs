namespace App.Models.Contracts
{
    public interface ITrainingType
    {
        string Description { get; }

        string WeightLiftTip { get; }

        string CardioTip { get; }
    }
}
