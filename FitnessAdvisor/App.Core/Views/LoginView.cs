using Terminal.Gui;

namespace App.Core.Views
{
    public class LoginView : View
    {
        private Button confirmLoginButton;
        private TextField usernameTextField;
        private TextField passwordTextField;

        public LoginView()
        {
            this.InitializeViewElements();
        }

        public Button LoginButton => this.confirmLoginButton;

        public TextField UsernameField => this.usernameTextField;

        public TextField PasswordField => this.passwordTextField;

    
        private void InitializeViewElements()
        {
            this.confirmLoginButton = new Button(12, 16, "_Sign in", true);
            this.usernameTextField = new TextField(14, 10, 40, "");
            this.passwordTextField = new TextField(14, 12, 40, "")
            {
                Secret = true
            };

            this.Add(
                  new Label(10, 8, "Please login...") { TextColor = (int)Color.BrightRed },
                  new Label(3, 10, "Username: "),
                  this.usernameTextField,
                  new Label(3, 12, "Password: "),
                  this.passwordTextField,
                  this.confirmLoginButton);
        }
    }
}
