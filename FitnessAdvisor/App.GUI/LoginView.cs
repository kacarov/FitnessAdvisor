using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace App.GUI
{
    public class LoginView : View
    {
        private Button loginButton;
        private TextField usernameTextField;
        private TextField passwordTextField;

        private readonly View view;
        private readonly Window window;

        private readonly View mainView;
        
        public LoginView(Window window, View mainView)
        {
            this.mainView = mainView;
            this.view = new View();
            this.window = window;

            this.InitializeViewElements();

            this.window.Add(view);

            this.AttachButtonAction(mainView);
        }

        //public View View => this.view;

        public Button LoginButton => this.loginButton;

        public string UsernameInput => this.usernameTextField.Text.ToString();

        public string PasswordInput => this.passwordTextField.Text.ToString();

        private void InitializeViewElements()
        {
            this.loginButton = new Button(12, 16, "Try to login");
            this.usernameTextField = new TextField(14, 10, 40, "");
            this.passwordTextField = new TextField(14, 12, 40, "")
            {
                Secret = true
            };

            this.view.Add(
                  new Label(10, 8, "Login view"),
                  new Label(3, 10, "Username: "),
                  this.usernameTextField,
                  new Label(3, 12, "Password: "),
                  this.passwordTextField,
                  this.loginButton);
        }

        private void AttachButtonAction(View mainView)
        {
            this.LoginButton.Clicked += () =>
            {
                this.window.Remove(this.view);             

                mainView.Add(new TextField(10, 5, 30, "Welcome to next Screen  " + this.UsernameInput));
            };
        }
    }
}
