using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {


                string pizzaName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
                string[] inpArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var flour = inpArg[1];
                var bakeriTech = inpArg[2];
                var weight = int.Parse(inpArg[3]);


                Dough dough = new Dough(flour, bakeriTech, weight);

                

                Pizza pizza = new Pizza(pizzaName, dough);


                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }
                    string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var topingName = line[1];
                    var topingWeight = int.Parse(line[2]);

                    var toping = new Topping(topingName, topingWeight);
                    
                    pizza.AddTopping(toping);
                }
                
                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():f2} Calories.");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
