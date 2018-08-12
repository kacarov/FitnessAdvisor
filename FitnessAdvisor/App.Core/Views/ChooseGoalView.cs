using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace App.Core.Views
{
    public class ChooseGoalView : View
    {
        private RadioGroup radioButtons;
        private Button selectButton;

        public ChooseGoalView() : base()
        {
            this.InitializeViewElements();
        }

        public RadioGroup RadioGroup => this.radioButtons;

        public Button SelectButton => this.selectButton;


        private void InitializeViewElements()
        {
            this.radioButtons = new RadioGroup(4, 12, new string[] { "Bulk", "Maintain", "Cutting" }, 0);
            this.selectButton = new Button(8, 19, "_Select");

            this.Add(
                  new Label(4, 8, "Choose your transformation strategy") { TextColor = (int)Color.BrightRed },
                  this.radioButtons,
                  this.selectButton);
        }
    }
}
