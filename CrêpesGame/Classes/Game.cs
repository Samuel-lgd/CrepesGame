using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace CrêpesGame.Classes
{
    public class Game
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Ingredient> IngredientsRestants { get; set; } = new List<Ingredient>();

        public string ClientName { get; set;}

        public int TempsEcoule { get; set; }

        public Crepe Crepe { get; set; }

        private int nbIngredient { get; set; }

        public Boolean StartGame(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;

            Console.WriteLine("Veuillez entrer votre nom :");
            string name = Console.ReadLine();

            Console.WriteLine("Bonjour " + name + " !\n");
            Console.WriteLine("Vous allez devoir préparer des crêpes pour vos clients.");
            Thread.Sleep(1000);
            Console.WriteLine("Chaque client va vous demander une crêpe avec des ingrédients spécifiques.");
            Thread.Sleep(1000);
            Console.WriteLine("L'objectif est d'écrire le nom des ingrédients le plus rapidement possible.");
            Thread.Sleep(1000);
            Console.WriteLine("Après avoir tapé tous les ingrédents, vous devrez estimer le prix de la crêpe\n\n");

            Console.WriteLine("Appuyez sur une touche pour commencer");
            Console.ReadKey();
            ClientArrive();
            Console.WriteLine("Appuyez sur une touche pour commencer à écrire les ingrédients et démarrer le chrono");
            Console.ReadKey();

            TypeIngredients();
            EstimatePrice();
            Console.WriteLine("Voulez-vous rejouer ? Y/N");
            string repRejouer = Console.ReadLine();
            if(repRejouer == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void ClientArrive()
        {
            ClientName = ClientNameGenerator();
            Console.WriteLine("Un client arrive dans votre crêperie, il s'appelle " + ClientName + " et il a l'air pressé !");
            Crepe crepe = new Crepe();
            crepe.Garnitures = CrepeGenerator();
            //crepe.DisplayIngredients();
            Crepe = crepe;
        }

        public string ClientNameGenerator()
        {
            List<string> listeClient = new List<string> { "Dinnerbone", "Jeb", "Notch", "Gabriel", "Notch","Herobrine","Alex","Steve","Grumm","Searge","Python","C418","Javachips","Pytheas","Xisuma","Zisteau","Zedaph"};
            int posClient = new Random().Next(listeClient.Count);
            return listeClient[posClient];

        }

        public List<Ingredient> CrepeGenerator()
        {
            List<Ingredient> listIngredient = new List<Ingredient>();
            Random rnd = new Random();
            int nbIngredient = rnd.Next(3, 8);
            for (int i = 0; i < nbIngredient; i++)
            {
                listIngredient.Add(Ingredients[rnd.Next(1, Ingredients.Count)]);
            }

            IngredientsRestants = listIngredient;
            return listIngredient;
        }   

        public void TypeIngredients()
        {
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            //Sert pour le calcul du score
            nbIngredient = Crepe.Garnitures.Count;

            int nberror = 0;
            while (IngredientsRestants.Count != 0)
            {
                Crepe.DisplayIngredients();
                Console.WriteLine("Il reste " + IngredientsRestants.Count + " ingrédients à taper");
                string ingredient = Console.ReadLine();

                //Permet de passé la phase de jeu
                if(ingredient =="BYPASSCHEAT")
                {
                    break;
                }

                
                if (VerifOrthographeIngredient(ingredient, IngredientsRestants))
                {
                    IngredientsRestants.Remove(IngredientsRestants.Find(x => x.Name == ingredient));
                }
                else
                {
                    //Console.WriteLine("Je pense qu'il y a une erreur !! haha^^");
                    MessageMoqueur(nberror);
                    nberror++;
                }
            }   
            chrono.Stop();
            TempsEcoule = (int) chrono.ElapsedMilliseconds / 1000;
        }

        public void EstimatePrice()
        {
            Console.WriteLine("A quel prix estimez-vous cette crêpe ? Attention, plus votre réponse est proche du prix exact, plus vous gagnez de points !");
            Console.WriteLine("Attention, " + ClientName + " est pressé, vous n'avez que 10 secondes pour répondre !");
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            string prix = Console.ReadLine();
            chrono.Stop();
            int tempsEcoule = (int) chrono.ElapsedMilliseconds / 1000;
            if (tempsEcoule > 10)
            {
                Console.WriteLine("Vous avez mis trop de temps à répondre, " + ClientName + " est parti sans payer !");
            }
            else
            {
                Console.WriteLine("Vous avez mis " + TempsEcoule + " secondes à fabriquer la crêpe");
                Console.WriteLine("Le prix de la crêpe était de " + Convert.ToInt32(Crepe.Prix) + " euros");
                Console.WriteLine("Vous avez répondu " + prix + " euros");
                //Calcul des points: plus le temps est faible, plus le prix est proche, plus on gagne de points
                // prendre en compte le nombre d'ingrédients, car plus il y a d'ingrédients, plus le temps de préparation est long
                int points = 0;
                if (Convert.ToInt32(Crepe.Prix) == Convert.ToInt32(prix))
                {
                    points = 100 + (10 - TempsEcoule * 7 / Crepe.Garnitures.Count);
                }
                else
                {
                    points = 100 - (int) Math.Abs((Crepe.Prix - Convert.ToDouble(prix)) * 10) - (TempsEcoule * 7 / nbIngredient);
                }

                Console.WriteLine("Vous avez gagné " + points + " points !");   
            }
            
        }


        public Boolean VerifOrthographeIngredient(string Ingredient, List<Ingredient> listIngredient)
        {
            if (Ingredient == null || Ingredient == "") { return false; }

            foreach(Ingredient ingr in listIngredient)
            {
                if(ingr.Name == Ingredient)
                {
                    return true;
                }
            }
            return false;
        }

        public void MessageMoqueur(int nberr)
        {
            string[] tabMsg = { "Je pense qu'il y a une erreur !! " , "Ah encore trompé", "Encore trompé :/", "Ca fait 4 fois là quand même", "5 fois là ", "Eeeeet non toujours pas", "t'es pas très bon dis donc", "Bon bon bon...","..."};
            if(nberr > 7){
                Console.WriteLine(tabMsg[tabMsg.Length - 1]);
            }
            else
            {
                Console.WriteLine(tabMsg[nberr]);
            }
            return;
        }

    }
}