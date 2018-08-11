using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace App.Core.Views
{
    public class BioDataView : View
    {
        private Button confirmButton;
        private TextField weightTextField;
        private TextField heightTextField;
        private TextField neckSizeeTextField;
        private TextField waistSizeTextField;
        private TextField hipsSizeTextField;

        public BioDataView() : base()
        {
            this.InitializeViewElements();
        }

        public Button ConfirmButton => this.confirmButton;

        public TextField WeightTextField => this.weightTextField;

        public TextField HeightTextField => this.heightTextField;

        public TextField NeckSizeeTextField => this.neckSizeeTextField;

        public TextField WaistSizeTextField => this.waistSizeTextField;

        public TextField HipsSizeTextField => this.hipsSizeTextField;


        private void InitializeViewElements()
        {
            this.confirmButton = new Button(12, 20, "_Update biodata", true);
            this.weightTextField = new TextField(14, 10, 40, "");
            this.heightTextField = new TextField(14, 12, 40, "");
            this.neckSizeeTextField = new TextField(14, 14, 40, "");
            this.waistSizeTextField = new TextField(14, 16, 40, "");
            this.hipsSizeTextField = new TextField(14, 18, 40, "");


            this.Add(
                  new Label(4, 8, "Please fill your metrics!") { TextColor = (int)Color.BrightRed },
                  new Label(3, 10, "Weight: "),
                  this.weightTextField,
                  new Label(3, 12, "Height: "),
                  this.heightTextField,
                   new Label(3, 14, "Neck size: "),
                  this.neckSizeeTextField,
                   new Label(3, 16, "Waist size: "),
                  this.waistSizeTextField,
                   new Label(3, 18, "Hips size: "),
                  this.hipsSizeTextField,
                  this.confirmButton);
        }
    }
}
