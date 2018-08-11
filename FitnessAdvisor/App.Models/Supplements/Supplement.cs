using App.Models.Enums;
using System;
using System.Text;

namespace App.Models.Supplements
{
    public class Supplement
    {
        private string brand;
        private string name;
        private int servingSize;
        private string description;

        public Supplement(string brand, string name, Category category, int servingSize, string description)
        {
            Brand = brand;
            Name = name;
            Category = category;
            ServingSize = servingSize;
            Description = description;
        }
        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                this.brand = value ?? throw new ArgumentException("Brand cannot be null");
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value ?? throw new ArgumentException("Name cannot be null");
            }
        }
        public Category Category { get; set; }
        public int ServingSize
        {
            get
            {
                return this.servingSize;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Brand cannot be null");
                }
                this.servingSize = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value ?? throw new ArgumentException("Description cannot be null");
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Brand: " + Brand);
            builder.AppendLine("Name: " + Name);
            builder.AppendLine("Category: " + Category);
            builder.AppendLine("Serving size: " + ServingSize);
            builder.AppendLine("Description: " + Description);
            return builder.ToString();
        }
    }
}
