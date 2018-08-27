using App.Data.Contracts;

namespace App.Core.Contracts
{
    public interface IUserService
    {
        IUserEntitie Login(string username, string password);

        void Register(IUserEntitie userToCreate);

        void UpdateUser(IUserEntitie loggedInUser);
    }
}
