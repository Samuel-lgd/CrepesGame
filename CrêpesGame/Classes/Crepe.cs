using CrêpesGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrêpesGame.Classes
{
    public class Crepe {
        public double Prix { get; set; }

        private List<Ingredient> garnitures;
        public List<Ingredient> Garnitures
        {
            get { return garnitures; }
            set
            {
                garnitures = value;
                RecalculerPrix();
            }
        }

        public TailleCrepe Taille { get; set; }

        public Crepe()
        {
            Garnitures = new List<Ingredient>();
            Taille = TailleCrepe.M;
        }

        public Crepe(List<Ingredient> garnitures, int prix, TailleCrepe taille)
        {
            Garnitures = garnitures;
            Prix = prix;
            Taille = taille;
        }

        public void DisplayIngredients()
        {
            Console.WriteLine("Ingrédients de la crêpe :");
            Console.WriteLine(new string('-', 25)); 

            foreach (Ingredient ingredient in Garnitures)
            {
                Console.WriteLine($"- {ingredient.Name}");
            }

            Console.WriteLine(new string('-', 25)); 
        }

        private void RecalculerPrix()
        {
            double prix = 0;

            foreach (Ingredient ingredient in Garnitures)
            {
                prix += ingredient.Price;
            }

            Prix = prix;
        }
    }

}