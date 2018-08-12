namespace App.Models.Contracts
{
    public interface IMealPlan
    {
        int CaloricNeeds { get; }

        int GramsOfProtein { get; }

        int GramsOfCarbs { get; }

        int GramsOfFats { get; }
    }
}
