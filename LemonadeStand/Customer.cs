using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Customer
    {
        public string name;
        public Customer()
        {
            name = "Customer";
        }

        public void Purchase(Player player, Recipe recipe, string weather ) // maybe add weather conditions
        {
            int number = UserInterface.GenerateRandom1to9();

            if(player.inventory.cups.Count > 0 && player.drinksAvailable > 0)
            {
                if (weather == "perfect")
                {
                    if (recipe.price <= 1)
                    {
                        if (number > 2)
                        {
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.AcceptMoney(recipe.price);
                        }
                        else
                        {
                            Console.WriteLine("A custo0mer walks by...");
                        }
                    }
                    else if (recipe.price > 1 && recipe.price < 3)
                    {
                        if (number > 3)
                        {
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.AcceptMoney(recipe.price);
                        }
                        else
                        {
                            Console.WriteLine("A customer walks by...");
                        }
                    }
                    else if (recipe.price >= 3)
                    {
                        if (number > 4)
                        {
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.AcceptMoney(recipe.price);
                        }
                        else
                        {
                            Console.WriteLine("A customer walks by...");
                        }
                    }

                }
                else if (weather == "good")
                {
                    if (recipe.price <= 1)
                    {
                        if (number > 3)
                        {
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.AcceptMoney(recipe.price);
                        }
                        else
                        {
                            Console.WriteLine("A customer walks by...");
                        }
                    }
                    else if (recipe.price > 1 && recipe.price < 3)
                    {
                        if (number > 4)
                        {
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.AcceptMoney(recipe.price);
                        }
                        else
                        {
                            Console.WriteLine("A customer walks by...");
                        }
                    }
                    else if (recipe.price >= 3)
                    {
                        if (number > 5)
                        {
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.AcceptMoney(recipe.price);
                        }
                        else
                        {
                            Console.WriteLine("A customer walks by...");
                        }
                    }
                }
                else // if weather is bad
                {
                    if (recipe.price <= 1)
                    {
                        if (number > 3)
                        {
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.AcceptMoney(recipe.price);
                        }
                        else
                        {
                            Console.WriteLine("A customer walks by...");
                        }
                    }
                    else if (recipe.price > 1 && recipe.price < 3)
                    {
                        if (number > 5)
                        {
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.AcceptMoney(recipe.price);
                        }
                        else
                        {
                            Console.WriteLine("A customer walks by...");
                        }
                    }
                    else if (recipe.price >= 3)
                    {
                        if (number > 6)
                        {
                            player.inventory.cups.RemoveAt(0);
                            player.wallet.AcceptMoney(recipe.price);
                        }
                        else
                        {
                            Console.WriteLine("A customer walks by...");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Don't have enough cups!");
            }

            
        }
    }
}
