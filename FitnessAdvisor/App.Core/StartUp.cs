using App.Core.Services;
using App.Core.Views;
using App.Data;
using App.Data.Entities;
using App.Models.Calculators;
using App.Models.Enums;
using App.Models.UserInfo;
using Mono.Terminal;
using System;
using System.Linq;
using Terminal.Gui;

namespace App.Core
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new DbContext();
            var userService = new UserService(db);

            UserEntitie loggedInUser = null;

            //Views
            LoginView loginScreen = new LoginView();
            RegisterView registerScreen = new RegisterView();
            StartScreen startScreen = new StartScreen();
            BioDataView bioScreen = new BioDataView();

            Application.Init();

            Toplevel top = Application.Top;
            Window window = new Window("FitApp") { X = 0, Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };

            top.Add(window);
            top.Add(startScreen);

            startScreen.LoginOptionButton.Clicked += () =>
            {
                loginScreen.LoginButton.Clicked += () =>
                {
                    // Try to get existing user
                    loggedInUser = userService.Login(loginScreen.UsernameField.Text.ToString(), loginScreen.PasswordField.Text.ToString());

                    if (loggedInUser != null)
                    {
                        window.Remove(loginScreen);

                        bioScreen.Add(new TextField(10, 5, 25, "Welcome " + loggedInUser.Username));
                        window.Add(bioScreen);

                        bioScreen.ConfirmButton.Clicked += () =>
                        {
                            BioDataEntitie newBioData = new BioDataEntitie
                            {
                                Weight = double.Parse(bioScreen.WeightTextField.Text.ToString()),
                                Height = double.Parse(bioScreen.HeightTextField.Text.ToString()),
                                NeckSize = double.Parse(bioScreen.NeckSizeeTextField.Text.ToString()),
                                WaistSize = double.Parse(bioScreen.WaistSizeTextField.Text.ToString()),
                                HipsSize = double.Parse(bioScreen.HipsSizeTextField.Text.ToString()),
                            };

                            loggedInUser.BioData = newBioData;
                            userService.UpdateBioData(loggedInUser);
                        };

                        Application.Run(window);
                    }
                    else
                    {
                        // Clear text fields
                        loginScreen.UsernameField.Text = "";
                        loginScreen.PasswordField.Text = "";

                        // Set cursor back to username TextField
                        loginScreen.SetFocus(loginScreen.UsernameField);

                        // Error dialog 
                        var d = new Dialog("Error",
                                    50,
                                    10,
                                    new Button("Ok", is_default: true)
                                    {
                                        Clicked = () =>
                                        {
                                            Application.RequestStop();
                                        }
                                    });

                        var errorText = new Label(1, 2, "Wrong user or password!")
                        {
                            TextAlignment = TextAlignment.Centered,
                            TextColor = (int)Color.BrightGreen
                        };
                        d.Add(errorText);

                        errorText = new Label(1, 3, "Try to login again..");
                        d.Add(errorText);

                        Application.Run(d);

                        //MainLoop.Invoke(() => )
                    }
                };

                var tframe = top.Frame;
                var loginTop = new Toplevel(tframe);
                var win = new Window("Login View")
                {
                    X = 0,
                    Y = 1,
                    Width = Dim.Fill(),
                    Height = Dim.Fill()
                };

                loginTop.Add(win);

                var quitLoginViewButtton = new Button("Go back");
                quitLoginViewButtton.Clicked += () => { loginTop.Running = false; };

                win.Add(loginScreen);
                win.Add(quitLoginViewButtton);
                Application.Run(loginTop);
            };

            startScreen.RegisterOptionButton.Clicked += () =>
            {
                //top.Remove(startScreen);

                // registerScreen = new RegisterView();
                //RegisterAction(userService, window, registerScreen,loginScreen);

                registerScreen.RegisterButton.Clicked += () =>
                {
                    var newUser = new UserEntitie
                    {
                        Username = registerScreen.UsernameField.Text.ToString(),
                        Password = registerScreen.PasswordField.Text.ToString(),
                        FirstName = registerScreen.FirstNameField.Text.ToString(),
                        LastName = registerScreen.LastNameField.Text.ToString(),
                        Email = registerScreen.EmailField.Text.ToString(),
                        BioData = null
                    };

                    userService.Register(newUser);
                    window.Remove(registerScreen);
                    // window.Add(loginScreen);


                    //TODO what after register?
                    window.Add(new TextField(10, 5, 99, "Successfully registered user with username:  " + registerScreen.UsernameField.Text.ToString()));
                    Application.Run();
                };


                var regTop = new Toplevel(top.Frame);
                var win = new Window("Register View")
                {
                    X = 0,
                    Y = 1,
                    Width = Dim.Fill(),
                    Height = Dim.Fill()
                };

                regTop.Add(win);
                var quitLoginViewButtton = new Button("Go back");
                quitLoginViewButtton.Clicked += () => { regTop.Running = false; };

                win.Add(registerScreen);

                win.Add(quitLoginViewButtton);

                Application.Run(regTop);

            };

            // Application.Refresh();
            Application.Run();

        }


        private static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit App", "Are you sure you want to quit FitnessAdvisor?", "Yes", "No");
            return n == 0;
        }

        private static void LoginAction(UserService userService, Window window, LoginView loginScreen)
        {

        }

        private static void RegisterAction(UserService userService, Window window, RegisterView registerScreen, LoginView loginScreen)
        {
            registerScreen.RegisterButton.Clicked += () =>
            {
                var newUser = new UserEntitie
                {
                    Username = registerScreen.UsernameField.Text.ToString(),
                    Password = registerScreen.PasswordField.Text.ToString(),
                    FirstName = registerScreen.FirstNameField.Text.ToString(),
                    LastName = registerScreen.LastNameField.Text.ToString(),
                    Email = registerScreen.EmailField.Text.ToString(),
                    BioData = null
                };

                userService.Register(newUser);
                window.Remove(registerScreen);
                // window.Add(loginScreen);


                //TODO 
                window.Add(new TextField(10, 5, 99, "Successfully registered user with username:  " + registerScreen.UsernameField.Text.ToString()));
                Application.Run();
            };
        }
    }
}
