namespace App.Models.Contracts
{
    public interface IMealPlan
    {
        int CaloricNeeds { get; set; }

        int GramsOfProtein { get; }

        int GramsOfCarbs { get; }

        int GramsOfFats { get; }
    }
}
