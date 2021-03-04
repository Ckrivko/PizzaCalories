using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaxToppingCount = 10;
        private const int NameMinLength = 1;
        private const int NameMaxLength = 15;

        private double totalCalories;
        private string name;
        private Dough dough;

        private List<Topping> topings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;

            this.topings = new List<Topping>();

        }

        public double TotalCalories { get; private set; }

        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException($"Pizza name should be between {NameMinLength} and {NameMaxLength} symbols.");
                }
                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.topings.Count == MaxToppingCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{MaxToppingCount}].");

            }

            this.topings.Add(topping);
        }

        public double GetTotalCalories()
        {
            this.totalCalories += this.dough.GetCalories();

            foreach (var topping in this.topings)
            {

                this.totalCalories += topping.GetCalories();

            }
            return this.totalCalories;

        }

    }
}
