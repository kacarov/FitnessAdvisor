﻿using App.Core.Services;
using App.Core.Views;
using App.Data;
using App.Data.Entities;
using App.Models.Calculators;
using App.Models.Contracts;
using App.Models.Enums;
using App.Models.GeneralPurpose;
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

            //TODO static or singleton
            var bodyCalculator = new BodyCalculator();

            UserEntitie loggedInUser = null;

            //Views
            LoginView loginScreen = new LoginView();
            RegisterView registerScreen = new RegisterView();
            StartScreen startScreen = new StartScreen();
            BioDataView bioScreen = new BioDataView();
            ChooseGoalView chooseGoalScreen = new ChooseGoalView();

            string finalAdvise = string.Empty;

            Application.Init();

            Toplevel top = Application.Top;
            Window window = new Window("FitApp") { X = 0, Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };

            top.Add(window);
            top.Add(startScreen);

            startScreen.LoginOptionButton.Clicked += () =>
            {
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

                var quitLoginViewButtton = new Button(50, 0, "Go back");
                quitLoginViewButtton.Clicked += () => { loginTop.Running = false; };

                win.Add(loginScreen);
                win.Add(quitLoginViewButtton);
                Application.Run(loginTop);
            };

            loginScreen.LoginButton.Clicked += () =>
            {
                // Try to get existing user
                loggedInUser = userService.Login(loginScreen.UsernameField.Text.ToString(), loginScreen.PasswordField.Text.ToString());

                // Successfull login
                if (loggedInUser != null)
                {
                    window.Remove(loginScreen);

                    bioScreen.Add(new Label(10, 5, "Welcome " + loggedInUser.Username));
                    window.Add(bioScreen);

                    bioScreen.ConfirmButton.Clicked += () =>
                    {
                        BioDataEntitie newBioData = new BioDataEntitie
                        {
                            Age = int.Parse(bioScreen.AgeTextField.Text.ToString()),
                            Weight = double.Parse(bioScreen.WeightTextField.Text.ToString()),
                            Height = double.Parse(bioScreen.HeightTextField.Text.ToString()),
                            NeckSize = double.Parse(bioScreen.NeckSizeeTextField.Text.ToString()),
                            WaistSize = double.Parse(bioScreen.WaistSizeTextField.Text.ToString()),
                            HipsSize = double.Parse(bioScreen.HipsSizeTextField.Text.ToString()),
                            Gender = int.Parse(bioScreen.GenderRadioGroup.Selected.ToString())
                        };

                        loggedInUser.BioData = newBioData;
                        userService.UpdateBioData(loggedInUser);

                        window.Remove(bioScreen);
                        window.Add(chooseGoalScreen);
                        Application.Run(window);
                    };

                    //window.Add(chooseGoalView);

                    //TODO
                    //Set transformation goal
                    var goalChoice = chooseGoalScreen.RadioGroup.Selected;

                    chooseGoalScreen.SelectButton.Clicked += () =>
                    {
                        //mapper BiodataEntitie to Biodata
                        BioData userBioData = new BioData(loggedInUser.BioData.Age, (GenderType)loggedInUser.BioData.Gender,
                            loggedInUser.BioData.Weight, loggedInUser.BioData.Height, loggedInUser.BioData.NeckSize,
                            loggedInUser.BioData.WaistSize, loggedInUser.BioData.HipsSize);

                        //mapper UserEntitie to User
                        User user = new User(loggedInUser.Username, userBioData);

                        var currentFatPerc = bodyCalculator.CalculateBodyFat(user);
                        var caloriesNeed = bodyCalculator.CalculateCalories(user);

                        //Bulk Use factory?
                        IBodyTransformationGoal goal = null;

                        switch (goalChoice)
                        {
                            case 0:
                                goal = new Bulk(user.BioData.Weight, currentFatPerc, caloriesNeed);
                                break;
                            case 1:
                                goal = new Maintain(user.BioData.Weight, currentFatPerc, caloriesNeed);
                                break;
                            case 2:
                                goal = new Cutting(user.BioData.Weight, currentFatPerc, caloriesNeed);
                                break;
                        }


                        window.Remove(chooseGoalScreen);

                        if (goal != null)
                        {
                            finalAdvise = goal.ToString();
                            window.Add(new TextView { Text = finalAdvise });
                        }

                        Application.Run(window);
                    };

                    //window.Add(new Label(5,5, finalAdvise));


                    Application.Run(window);
                }
                // Login failed
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
                    startScreen.Remove(startScreen.RegisterOptionButton);
                    //startScreen.Remove(startScreen.LoginOptionButton);

                    //TODO what after register?
                    window.Add(new Label(10, 5, "Successfully registered user with username:  " + registerScreen.UsernameField.Text.ToString()));
                    //window.Add(new TextField(10, 15, 99, "Click to continue!"));

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
                var quitLoginViewButtton = new Button(50, 0, "Go back");
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

        /*    BioData bioData = new BioData(23, GenderType.Male, 93, 190, 42, 86, 90);
              User ivan = new User("Ivan", bioData);
              BodyCalculator bodyCalculator = new BodyCalculator();
              ivan.Goal = new Bulk(ivan.BioData.Weight, bodyCalculator.CalculateBodyFat(ivan), bodyCalculator.CalculateCalories(ivan));
              Supplement amix = new Supplement("Amix", "Fusion", Category.Protein, 70, "...");
              ivan.Goal.AddSupplement(amix);
              Console.WriteLine(ivan.Goal.ToString());*/
    }
}
