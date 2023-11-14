

//Le but du jeu est de faire des crêpes le plus rapidement possible en écrivant les ingrédients au clavier pour constituer la crêpe finale

using CrêpesGame.Classes;

static void Main() {
    afficherTitre();
    afficherMenu();
}


static void afficherTitre()
{
    Console.WriteLine("******************************");
    Console.WriteLine("* Bienvenue dans Crepe Farmer *");
    Console.WriteLine("******************************\n");
}

static void afficherMenu()
{
    Console.WriteLine("1 | Jouer");
    Console.WriteLine("2 | Quitter");
    string Input = Console.ReadLine();

    switch (Input)
    {
        case "1":
            Game game = new Game();
            game.StartGame(genererIngredients());
            break;

        case "2":
            Console.WriteLine("Au revoir !");
            break;

        default:
            // Code to execute if none of the cases match
            Console.WriteLine("ERREUR DE BASE VIRALE");
            break;
    }
}

static List<Ingredient> genererIngredients()
{
    return new List<Ingredient>
    {
        new Ingredient("Nutella", randomizePrice(2)),
        new Ingredient("Chantilly",  randomizePrice(1)),
        new Ingredient("Confiture",randomizePrice(1.5)),
        new Ingredient("Fraise", randomizePrice(2.5)),
        new Ingredient("Banane", randomizePrice(3)),
        new Ingredient("Saucisson", randomizePrice(5)),
        new Ingredient("Jambon", randomizePrice(3)),
        new Ingredient("Oeuf", randomizePrice(1)),
        new Ingredient("Fromage", randomizePrice(1.5)),
        new Ingredient("Poulet", randomizePrice(3)),
        new Ingredient("Beurre", randomizePrice(1)),
        new Ingredient("Miel", randomizePrice(1.5)),
        new Ingredient("Champignon", randomizePrice(3)),
        new Ingredient("Chorizo", randomizePrice(1)),
        new Ingredient("Béchamelle", randomizePrice(1.5)),
        new Ingredient("Poivron", randomizePrice(3)),
        new Ingredient("Crème", randomizePrice(1)),
        new Ingredient("Patate", randomizePrice(1.5)),
    };
}

static double randomizePrice(double price)
{
    Random random = new Random();
    double facteurAleatoire = random.NextDouble() * (1.2 - 0.8) + 0.8; // Génère un nombre aléatoire entre 0.8 et 1.2
    return price * facteurAleatoire;
}



Main();

