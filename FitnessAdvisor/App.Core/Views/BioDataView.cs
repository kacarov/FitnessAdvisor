﻿using App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace App.Core.Views
{
    public class BioDataView : View
    {
        private Button confirmButton;
        private TextField ageTextField;
        private RadioGroup genderRadioGroup;
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

        public TextField AgeTextField => this.ageTextField;

        public TextField WeightTextField => this.weightTextField;

        public TextField HeightTextField => this.heightTextField;

        public TextField NeckSizeeTextField => this.neckSizeeTextField;

        public TextField WaistSizeTextField => this.waistSizeTextField;

        public TextField HipsSizeTextField => this.hipsSizeTextField;

        public RadioGroup GenderRadioGroup => this.genderRadioGroup;

        private void InitializeViewElements()
        {
            this.confirmButton = new Button(12, 24, "_Update biodata", true);
            this.ageTextField = new TextField(14, 8, 40, "");
            this.weightTextField = new TextField(14, 10, 40, "");
            this.heightTextField = new TextField(14, 12, 40, "");
            this.neckSizeeTextField = new TextField(14, 14, 40, "");
            this.waistSizeTextField = new TextField(14, 16, 40, "");
            this.hipsSizeTextField = new TextField(14, 18, 40, "");
            this.genderRadioGroup = new RadioGroup(14, 20, new string[] { GenderType.Male.ToString(), GenderType.Female.ToString() });

            this.Add(
                  new Label(4, 6, "Please fill your metrics!") { TextColor = (int)Color.BrightRed },
                  new Label(3, 8, "Age: "),
                  this.ageTextField,
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
                  new Label(3, 20, "Gender: "),
                  this.genderRadioGroup,
                  this.confirmButton);
        }
    }
}
