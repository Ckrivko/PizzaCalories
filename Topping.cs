using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string name;
        private int weight;

        private double calories;
       
        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;

        }

        public double Calories { get; private set; }

        public string Name
        {
            get => this.name;
            set
            {

                ; Validator.ThrowIsNotAllowed(new HashSet<string> { "meat", "veggies", "cheese", "sauce" },
                                                                value.ToLower(),
                                                                $"Cannot place {value} on top of your pizza.");

                this.name = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            set
            {
                Validator.ThrowIfNumIsNotInRange(MinWeight, MaxWeight, value, $"{this.Name} weight should be in the range [{MinWeight}..{MaxWeight}].");
                this.weight = value;

            }

        }
        public double GetCalories()
        {
            string nameAsLower = this.Name.ToLower();

            this.calories += 2 * this.weight;

            if (nameAsLower == "meat")
            {
                this.calories *= 1.2;
            }

            else if (nameAsLower == "veggies")
            {
                this.calories *= 0.8;
            }
            else if (nameAsLower == "cheese")
            {
                this.calories *= 1.1;
            }
            else if (nameAsLower == "sauce")
            {
                this.calories *= 0.9;
            }


            return this.calories;
        }
    }
}
