namespace App.Data.Contracts
{
    public interface IUserEntitie
    {
        int UserId { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        IBioDataEntitie BioData { get; set; }

        string TrainingProgramAdvise { get; set; }
    }
}
