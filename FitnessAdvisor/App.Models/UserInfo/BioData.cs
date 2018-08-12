using App.Models.Contracts;
using App.Models.Enums;
using System;

namespace App.Models.UserInfo
{
    public class BioData : IBioData
    {
        // NEED VALIDATIONS, ENCAPSULATION, ACCESS MODIFIERS !!!!
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
            set
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
            set
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
