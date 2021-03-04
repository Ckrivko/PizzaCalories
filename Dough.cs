using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private const string InvalidExeptionMessage = "Invalid type of dough.";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        private double calories;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
           
        }


        public double Calories
        {
            get => this.calories;
           private set
            {
                this.calories = GetCalories(); //??
            }
        }

        public string FlourType
        {
            get => this.flourType;
            set
            {
                string valueAsLower = value.ToLower();

                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new AggregateException(InvalidExeptionMessage);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                string valueAsLower = value.ToLower();

                if (valueAsLower != "crispy" && valueAsLower != "chewy" && valueAsLower != "homemade")
                {
                    throw new AggregateException(InvalidExeptionMessage);
                }
                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            set
            {

                Validator.ThrowIfNumIsNotInRange(MinWeight, MaxWeight, value, $"Dough weight should be in the range[{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }

        }

        public double GetCalories()
        {
            string flouTypeAsLower = this.flourType.ToLower();

            this.calories = 2 * this.weight;
           
            if (flouTypeAsLower == "white")
            {
                this.calories *= 1.5;
            }
            //if (this.flourType == "wholegrain")
            //{
            //    this.calories *= 1.0;
            //}

            string bakingTechAsLower = this.bakingTechnique.ToLower();


            if (bakingTechAsLower == "crispy")
            {
                this.calories *= 0.9;
            }
            else if (bakingTechAsLower == "chewy")
            {
                this.calories *= 1.1;
            }
            //else if (bakingTechAsLower == "homemade")
            //{
            //    this.calories *= 1.0;
            //}
            
            return this.calories;
        }

    }
}
