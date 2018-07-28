using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.UserInfo
{
    public class BioData
    {
        private double weight;
        private double height;
        private double neckSize;
        private double waistSize;
        private double hipsSize;
        private double bodyFatPercentage;

        public BioData(double weight, double height, double neckSize, double waistSize, double hipSize)
        {
            Weight = weight;
            Height = height;
            NeckSize = neckSize;
            WaistSize = waistSize;
            HipsSize = hipsSize;
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }
        public double NeckSize
        {
            get
            {
                return this.neckSize;
            }
            set
            {
                this.neckSize = value;
            }
        }
        public double WaistSize
        {
            get
            {
                return this.waistSize;
            }
            set
            {
                this.waistSize = value;
            }
        }
        public double HipsSize
        {
               get
            {
                return this.hipsSize;
            }
            set
            {
                this.hipsSize = value;
            }
        
        }
        public double BodyFatPercentage
        {
            get
            {
                return this.bodyFatPercentage;
            }
            set
            {
                this.bodyFatPercentage = value;
            }
        }
    }
}
