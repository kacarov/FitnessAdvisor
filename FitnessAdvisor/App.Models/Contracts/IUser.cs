namespace App.Models.Contracts
{
    public interface IUser
    {
        string Username { get; }

        IBioData BioData { get; }
    }
}
