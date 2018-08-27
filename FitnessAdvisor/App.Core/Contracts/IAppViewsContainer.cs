using App.Core.Views;

namespace App.Core.Contracts
{
    public interface IAppViewsContainer
    {
        LoginView LoginScreen { get; }

        RegisterView RegisterScreen { get; }

        StartView StartScreen { get; }

        BioDataView BioScreen { get; }

        ChooseGoalView ChooseGoalScreen { get; }
    }
}
