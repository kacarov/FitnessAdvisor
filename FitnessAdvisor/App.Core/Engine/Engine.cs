using App.Core.Contracts;
using App.Core.Factory;
using App.Data.Contracts;
using App.Data.Entities;
using App.Models.Contracts;
using App.Models.Enums;
using App.Models.GeneralPurpose;
using App.Models.UserInfo;
using Terminal.Gui;

namespace App.Core.Engine
{
    public class Engine : IEngine
    {
        private readonly IDbContext db;
        private readonly IUserService userService;
        private readonly IBodyCalculator bodyCalculator;
        private readonly IAppViewsContainer appViews;
        private readonly ITransformationGoalFactory transformationGoalFactory;
        private IUserEntitie loggedInUser = null;

        public Engine(IDbContext db,
                IUserService userService,
                IBodyCalculator bodyCalculator,
                IAppViewsContainer appViews,
                ITransformationGoalFactory transformationGoalFactory)
        {
            this.db = db;
            this.userService = userService;
            this.bodyCalculator = bodyCalculator;
            this.appViews = appViews;
            this.transformationGoalFactory = transformationGoalFactory;
        }

        public void Run()
        {
            Application.Init();

            Toplevel top;
            Window window;

            this.InitializeTopAndWindow(out top, out window);

            //setup startscreen buttons actions
            this.SetupStartScreenLoginButtonAction(top);
            this.SetupStartScreenRegisterButtonAction(top);

            this.SetupRegisterScreenButtonAction(window);

            this.SetupLoginScreenLoginButtonAction(window);

            Application.Run();
        }

        private void InitializeTopAndWindow(out Toplevel top, out Window window)
        {
            top = Application.Top;
            window = new Window("FitApp")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(window);
            top.Add(this.appViews.StartScreen);
        }

        private void SetupLoginScreenLoginButtonAction(Window window)
        {
            this.appViews.LoginScreen.LoginButton.Clicked += () =>
            {
                // Try to get existing user
                loggedInUser = userService.Login(this.appViews.LoginScreen.UsernameField.Text.ToString(), this.appViews.LoginScreen.PasswordField.Text.ToString());

                // Successfull login
                if (loggedInUser != null)
                {
                    this.HandleSuccessfulLogin(window);
                }
                // Login failed
                else
                {
                    this.SetupFailedLoginDialogPopUp();
                }
            };
        }

        private void HandleSuccessfulLogin(Window window)
        {
            window.Remove(this.appViews.LoginScreen);

            //check if user already got training program advise
            if (!string.IsNullOrEmpty(loggedInUser.TrainingProgramAdvise))
            {
                window.Add(new TextView { Text = loggedInUser.TrainingProgramAdvise });

                Application.Run(window);
            }
            else
            {
                this.SetupBioScreenView(loggedInUser, window);

                //Set transformation goal     
                this.SetupTransformationGoalScreenButtonActions(window);
            };

            Application.Run(window);
        }

        private void SetupTransformationGoalScreenButtonActions(Window window)
        {
            this.appViews.ChooseGoalScreen.SelectButton.Clicked += () =>
            {
                //mapper BiodataEntitie to Biodata
                BioData userBioData = new BioData(loggedInUser.BioData.Age, (GenderType)loggedInUser.BioData.Gender,
                    loggedInUser.BioData.Weight, loggedInUser.BioData.Height, loggedInUser.BioData.NeckSize,
                    loggedInUser.BioData.WaistSize, loggedInUser.BioData.HipsSize);

                //mapper UserEntitie to User
                User user = new User(loggedInUser.Username, userBioData);

                var currentFatPerc = this.bodyCalculator.CalculateBodyFat(user);
                var caloriesNeed = this.bodyCalculator.CalculateCalories(user);


                IBodyTransformationGoal goal = transformationGoalFactory.GetGoal(this.appViews.ChooseGoalScreen.RadioGroup.Selected,
                                                                                 user.BioData.Weight,
                                                                                 currentFatPerc,
                                                                                 caloriesNeed);

                window.Remove(this.appViews.ChooseGoalScreen);
                string finalAdvise = string.Empty;

                if (goal != null)
                {
                    user.SetTransformationGoal(goal);
                    finalAdvise = user.Goal.ToString();

                    //Update user goal at db
                    loggedInUser.TrainingProgramAdvise = finalAdvise;
                    userService.UpdateUser(loggedInUser);

                    window.Add(new TextView { Text = finalAdvise });
                }

                Application.Run(window);
            };
        }

        private void SetupFailedLoginDialogPopUp()
        {
            // Clear text fields
            this.appViews.LoginScreen.UsernameField.Text = "";
            this.appViews.LoginScreen.PasswordField.Text = "";

            // Set cursor back to username TextField
            this.appViews.LoginScreen.SetFocus(this.appViews.LoginScreen.UsernameField);

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
        }

        private void SetupStartScreenRegisterButtonAction(Toplevel top)
        {
            this.appViews.StartScreen.RegisterOptionButton.Clicked += () =>
            {
                //top.Remove(startScreen);

                // registerScreen = new RegisterView();
                //RegisterAction(userService, window, registerScreen,loginScreen);

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

                win.Add(this.appViews.RegisterScreen);

                win.Add(quitLoginViewButtton);

                Application.Run(regTop);
            };
        }

        private void SetupBioScreenView(IUserEntitie loggedInUser, Window window)
        {
            this.appViews.BioScreen.Add(new Label(10, 3, "Welcome " + loggedInUser.Username) { TextAlignment = TextAlignment.Centered });
            window.Add(this.appViews.BioScreen);

            this.appViews.BioScreen.ConfirmButton.Clicked += () =>
            {
                BioDataEntitie newBioData = new BioDataEntitie
                {
                    Age = int.Parse(this.appViews.BioScreen.AgeTextField.Text.ToString()),
                    Weight = double.Parse(this.appViews.BioScreen.WeightTextField.Text.ToString()),
                    Height = double.Parse(this.appViews.BioScreen.HeightTextField.Text.ToString()),
                    NeckSize = double.Parse(this.appViews.BioScreen.NeckSizeeTextField.Text.ToString()),
                    WaistSize = double.Parse(this.appViews.BioScreen.WaistSizeTextField.Text.ToString()),
                    HipsSize = double.Parse(this.appViews.BioScreen.HipsSizeTextField.Text.ToString()),
                    Gender = int.Parse(this.appViews.BioScreen.GenderRadioGroup.Selected.ToString())
                };

                loggedInUser.BioData = newBioData;
                userService.UpdateUser(loggedInUser);

                window.Remove(this.appViews.BioScreen);
                window.Add(this.appViews.ChooseGoalScreen);
                this.appViews.ChooseGoalScreen.SetFocus(this.appViews.ChooseGoalScreen.RadioGroup);

                Application.Run(window);
            };
        }

        private void SetupRegisterScreenButtonAction(Window window)
        {
            this.appViews.RegisterScreen.RegisterButton.Clicked += () =>
            {
                var newUser = new UserEntitie
                {
                    Username = this.appViews.RegisterScreen.UsernameField.Text.ToString(),
                    Password = this.appViews.RegisterScreen.PasswordField.Text.ToString(),
                    FirstName = this.appViews.RegisterScreen.FirstNameField.Text.ToString(),
                    LastName = this.appViews.RegisterScreen.LastNameField.Text.ToString(),
                    Email = this.appViews.RegisterScreen.EmailField.Text.ToString(),
                    BioData = null
                };

                userService.Register(newUser);

                window.Remove(this.appViews.RegisterScreen);
                this.appViews.StartScreen.Remove(this.appViews.StartScreen.RegisterOptionButton);
                //startScreen.Remove(startScreen.LoginOptionButton);

                //window.Add(new Label(10, 5, "Successfully registered user with username:  " + registerScreen.UsernameField.Text.ToString()));

                Application.Run();
            };
        }

        private void SetupStartScreenLoginButtonAction(Toplevel top)
        {
            this.appViews.StartScreen.LoginOptionButton.Clicked += () =>
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

                win.Add(this.appViews.LoginScreen);
                win.Add(quitLoginViewButtton);
                Application.Run(loginTop);
            };
        }
    }
}
