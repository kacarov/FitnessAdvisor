using App.Core.Contracts;
using App.Core.Views;

namespace App.Core.Engine
{
    public class AppViewsContainer : IAppViewsContainer
    {
        private readonly LoginView loginScreen;
        private readonly RegisterView registerScreen;
        private readonly StartView startScreen;

        private readonly BioDataView bioScreen;
        private readonly ChooseGoalView chooseGoalScreen;

        public AppViewsContainer(LoginView loginScreen, RegisterView registerScreen, StartView startScreen, BioDataView bioScreen, ChooseGoalView chooseGoalScreen)
        {
            this.loginScreen = loginScreen;
            this.registerScreen = registerScreen;
            this.startScreen = startScreen;
            this.bioScreen = bioScreen;
            this.chooseGoalScreen = chooseGoalScreen;
        }

        public LoginView LoginScreen => this.loginScreen;
        public RegisterView RegisterScreen => this.registerScreen;
        public StartView StartScreen => this.startScreen;
        public BioDataView BioScreen => this.bioScreen;
        public ChooseGoalView ChooseGoalScreen => this.chooseGoalScreen;
    }
}
