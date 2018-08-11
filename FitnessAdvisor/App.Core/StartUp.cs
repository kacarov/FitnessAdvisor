using App.Core.Services;
using App.Core.Views;
using App.Data;
using App.Data.Entities;
using App.Models.Calculators;
using App.Models.Enums;
using App.Models.GeneralPurpose;
using App.Models.Supplements;
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
            UserEntitie loggedUser = null;

            Application.Init();

            var top = Application.Top;
            var window = new Window("FitApp") { X = 0, Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };

            top.Add(window);

            var mainView = new View();
            window.Add(mainView);

            // Add start screen with options Login or Register 
            //var startScreenView = 


            var loginScreen = new LoginView();
            window.Add(loginScreen);

            loginScreen.LoginButton.Clicked += () =>
               {
                   // Try to get existing user
                   var loggedInUser = userService.Login(loginScreen.UsernameField.Text.ToString(), loginScreen.PasswordField.Text.ToString());

                   if (loggedInUser != null)
                   {
                       //Go to home screen -> add BioData
                       window.Remove(loginScreen);
                       mainView.Add(new TextField(10, 5, 30, "Welcome to next Screen  " + loginScreen.UsernameField.Text.ToString()));
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

                       //var errorQuery = new Dialog("Error", 80, 5);
                       //window.Add(errorQuery);

                   }


               };

            //var registerScreen = new RegisterView();
            //window.Add(registerScreen);

            //registerScreen.RegisterButton.Clicked += () =>
            //{
            //    var newUser = new UserEntitie
            //    {
            //        Username = registerScreen.UsernameField.Text.ToString(),
            //        Password = registerScreen.PasswordField.Text.ToString(),
            //        FirstName = registerScreen.FirstNameField.Text.ToString(),
            //        LastName = registerScreen.LastNameField.Text.ToString(),
            //        Email = registerScreen.EmailField.Text.ToString(),
            //        BioData = null
            //    };

            //    userService.Register(newUser);
            //    window.Remove(registerScreen);
            //    //window.Add(loginScreen);
            //    mainView.Add(new TextField(10, 5, 99, "Successfully registered user with username:  " + registerScreen.UsernameField.Text.ToString()));

            //};


            Application.Run();

            //var newUser = new UserEntitie
            //{
            //    Username = "Gosho",
            //    Email = "dsakd@abv.bg",
            //    Password = "123",
            //    FirstName = "uvan",
            //    LastName = "Ivanov",
            //};


            //userService.Register(newUser);

            //db.UserRepository
            //    .GetAllUsers()
            //    .ToList()
            //    .ForEach(u => Console.WriteLine($"{u.UserId}  {u.Username} {u.Password}"));

            //var bioDataToAdd = new BioDataEntitie()
            //{
            //    Weight = 90,
            //    Height = 190,
            //    NeckSize = 60,
            //    WaistSize = 95,
            //};

            //var existingUser = db.UserRepository.GetById(5);

            //existingUser.BioData = bioDataToAdd;

            ////var editedUser = new UserEntitie()
            ////{
            ////    Username = existingUser.Username,
            ////    Email = existingUser.Email,
            ////    Password = existingUser.Password,
            ////    FirstName = existingUser.FirstName,
            ////    LastName = existingUser.LastName,
            ////    BioData = bioDataToAdd
            ////};

            //db.UserRepository.Update(existingUser);

            //db.UserRepository
            //.GetAllUsers()
            //.ToList()
            //.ForEach(u => Console.WriteLine($"{u.UserId}  {u.Username} {u.Password}"));

          /*  BioData bioData = new BioData(23, GenderType.Male, 93, 190, 42, 86, 90);
            User ivan = new User("Ivan", bioData);
            BodyCalculator bodyCalculator = new BodyCalculator();
            ivan.Goal = new Bulk(ivan.BioData.Weight, bodyCalculator.CalculateBodyFat(ivan), bodyCalculator.CalculateCalories(ivan));
            Supplement amix = new Supplement("Amix", "Fusion", Category.Protein, 70, "...");
            ivan.Goal.AddSupplement(amix);
            Console.WriteLine(ivan.Goal.ToString());*/
        }
    }
}
