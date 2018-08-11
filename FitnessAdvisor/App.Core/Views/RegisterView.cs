﻿using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace App.Core.Views
{
    public class RegisterView : View
    {
        private Button registerButton;
        private TextField usernameTextField;
        private TextField passwordTextField;
        private TextField firstNameTextField;
        private TextField lastNameTextField;
        private TextField emailTextField;

        public RegisterView()
        {
            this.InitializeViewElements();
        }

        public Button RegisterButton => this.registerButton;

        public TextField UsernameField => this.usernameTextField;

        public TextField PasswordField => this.passwordTextField;

        public TextField FirstNameField => this.firstNameTextField;

        public TextField LastNameField => this.lastNameTextField;

        public TextField EmailField => this.emailTextField;


        private void InitializeViewElements()
        {
            this.registerButton = new Button(12, 20, "_Register", true);
            this.usernameTextField = new TextField(14, 10, 40, "");
            this.passwordTextField = new TextField(14, 12, 40, "")
            {
                Secret = true
            };
            this.firstNameTextField = new TextField(14, 14, 40, "");
            this.lastNameTextField = new TextField(14, 16, 40, "");
            this.emailTextField = new TextField(14, 18, 40, "");


            this.Add(
                  new Label(10, 8, "Fill register info...") { TextColor = (int)Color.BrightRed },
                  new Label(3, 10, "Username: "),
                  this.usernameTextField,
                  new Label(3, 12, "Password: "),
                  this.passwordTextField,
                   new Label(3, 14, "First Name: "),
                  this.firstNameTextField,
                   new Label(3, 16, "Last Name: "),
                  this.lastNameTextField,
                   new Label(3, 18, "Email: "),
                  this.emailTextField,
                  this.registerButton);
        }
    }
}