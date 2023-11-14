using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrêpesGame.Classes
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Ingredient(string name, double price ) 
        { 
            Name = name;
            Price = price;
        }
    }
}
