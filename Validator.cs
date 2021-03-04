using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public static class Validator
    {
        public static void ThrowIfNumIsNotInRange(int minValue, int maksValue,int num, string exeptionMessage)
        {

            if (num < minValue || num > maksValue)
            {
                throw new ArgumentException(exeptionMessage);
            }
            
        }

        public static void ThrowIsNotAllowed(HashSet<string> allowedStrings, string value, string exeptionMessage)
        {
            if (!allowedStrings.Contains(value))
            {
                throw new ArgumentException(exeptionMessage);
            }
        }
    }
}
