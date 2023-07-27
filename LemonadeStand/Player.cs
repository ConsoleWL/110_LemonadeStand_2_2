using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        string name;
        internal int drinksAvailable;
        internal int drinksSold;

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
            name = "Player";
            drinksAvailable = 0;
            drinksSold = 0;
        }

        // member methods (CAN DO)
        public void DisplayInvetory()
        {
            Console.WriteLine($"\nYou have ${Math.Round(wallet.Money)}");
            Console.WriteLine($"You have {inventory.lemons.Count} lemons");
            Console.WriteLine($"You have {inventory.sugarCubes.Count} sugar cubes");
            Console.WriteLine($"You have {inventory.iceCubes.Count} ice cubes");
            Console.WriteLine($"You have {inventory.cups.Count} cups\n");
        }

        public void MakeAPitcher(int amountOfPitchers)
        {
            bool itemsAvailable = true;

            int lemonsForPitcher = recipe.numberOfLemons * amountOfPitchers;
            int sugarForPitcher = recipe.numberOfSugarCubes * amountOfPitchers;
            int iceForPitcher = recipe.numberOfIceCubes * amountOfPitchers;

            try
            {
                inventory.lemons.RemoveRange(0, lemonsForPitcher);
                inventory.sugarCubes.RemoveRange(0, sugarForPitcher);
                inventory.iceCubes.RemoveRange(0, iceForPitcher);
            }
            catch (Exception)
            {
                itemsAvailable = false;
                Console.WriteLine($"You dont have enough items");
            }

            if (itemsAvailable == true)
            {
                // 1 pitcher = 8 cups.
                drinksAvailable = 8 * amountOfPitchers;
            }
        }
    }
}
