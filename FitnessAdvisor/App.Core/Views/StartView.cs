
using Terminal.Gui;

namespace App.Core.Views
{
    public class StartView : View
    {
        private Button loginOptionButton;
        private Button registerOptionButton;

        public StartView()
        {
            this.InitializeViewElements();
        }

        public Button LoginOptionButton => this.loginOptionButton;

        public Button RegisterOptionButton => this.registerOptionButton;


        private void InitializeViewElements()
        {
            this.loginOptionButton = new Button(115, 10, "_Login", true) { Frame = new Rect(20, 10, 55, 15) };
            this.registerOptionButton = new Button(50, 50, "_Register") { Frame = new Rect(50, 10, 55, 15) };


            this.Add(
                  new Label(20, 5, "Welcome to Fitness Advisor Application!") { TextColor = (int)Color.BrightRed },
                  //new Label(3, 10, "Username: "),
                  this.loginOptionButton,
                  this.registerOptionButton);
        }
    }
}
