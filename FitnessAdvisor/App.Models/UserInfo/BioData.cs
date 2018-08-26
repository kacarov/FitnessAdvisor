using App.Models.Contracts;
using App.Models.Enums;
using System;

namespace App.Models.UserInfo
{
    //Holds user's bio data.
    public class BioData : IBioData
    {
        private int age;
        private GenderType gender;
        private double weight;
        private double height;
        private double neckSize;
        private double waistSize;
        private double hipsSize;
        private double bodyFatPercentage;

        public BioData(int age, GenderType gender, double weight, double height, double neckSize, double waistSize, double hipsSize)
        {
            this.Age = age;
            this.Gender = gender;
            this.Weight = weight;
            this.Height = height;
            this.NeckSize = neckSize;
            this.WaistSize = waistSize;
            this.HipsSize = hipsSize;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 16 || value > 120)
                {
                    throw new ArgumentException("Age must be between 16 and 120");
                }
                this.age = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                this.gender = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 30 || value > 300)
                {
                    throw new ArgumentException("Weight must be between 30 and 300 kg.");
                }
                this.weight = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 100 || value > 300)
                {
                    throw new ArgumentException("Height must be in range 100 and 300 cm.");
                }
                this.height = value;
            }
        }

        public double NeckSize
        {
            get
            {
                return this.neckSize;
            }
            private set
            {
                if (value < 30 || value > 90)
                {
                    throw new ArgumentException("Neck size must be between 30 and 90 cm.");
                }
                this.neckSize = value;
            }
        }

        public double WaistSize
        {
            get
            {
                return this.waistSize;
            }
            private set
            {
                if(value < 50 || value > 250)
                {
                    throw new ArgumentException("Waist size must be between 50 and 250 cm.");
                }
                this.waistSize = value;
            }
        }

        public double HipsSize
        {
            get
            {
                return this.hipsSize;
            }
            private set
            {
                if(value < 50 || value > 250)
                {
                    throw new ArgumentException("Hip size must be between 50 and 250 cm.");
                }
                this.hipsSize = value;
            }
        }

        public double BodyFatPercentage
        {
            get
            {
                return this.bodyFatPercentage;
            }
            private set
            {
                this.bodyFatPercentage = value;
            }
        }
    }
}
