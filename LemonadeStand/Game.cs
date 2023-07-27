using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        int currentDay;
        Player player;
        List<Day> days;
        Store store;

        public Game()
        {
            currentDay = 1;
            player = new Player();
            store = new Store();
            days = new List<Day>
            {
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day()
            };
        }

        public void Welcome()
        {
            Console.WriteLine("Welcome to Lemonade Stand!");
            Console.WriteLine("You have 7 days to make as much money as you can.");
            Console.WriteLine("The weather, along with your pricing, can affect your success.");
            Console.WriteLine("Can you make the big bucks");
        }

        public void WeatherChanger()
        {
            int changeWeather = UserInterface.GenerateRandom1to9();
            if (changeWeather < 3)
            {
                //then well change it
                if (days[currentDay -1].weather.condition == "perfect")
                {
                    days[currentDay - 1].weather.condition = "bad";
                    days[currentDay - 1].weather.temperature = 50;
                    days[currentDay - 1].weather.predictedForecast = days[currentDay -1].weather.weatherConditions[2];
                }
                else if (days[currentDay - 1].weather.condition == "bad")
                {
                    days[currentDay - 1].weather.condition = "perfect";
                    days[currentDay - 1].weather.temperature = 80;
                    days[currentDay - 1].weather.predictedForecast = days[currentDay - 1].weather.weatherConditions[2];

                }
                else
                {
                    days[currentDay -1].weather.condition = "perfect";
                    days[currentDay - 1].weather.temperature = 80;
                    days[currentDay - 1].weather.predictedForecast = days[currentDay - 1].weather.weatherConditions[2];
                }
            }
        }

        public void DisplayPrices()
        {
            Console.WriteLine($"Lemon: $0.5  SugarCube: $0.10 IceCube: $0.01 Cup: $0.25");
        }

        public void CustomerPurchase()
        {
            for (int i = 0; i < days[currentDay -1].customers.Count - 1; i++)
            {
                if(player.drinksAvailable > 0)
                {
                    days[currentDay - 1].customers[i].Purchase(player, player.recipe, days[currentDay - 1].weather.condition);
                    Console.WriteLine($"A customer buys a cup of {player.recipe.name}");
                    
                    player.drinksAvailable--;
                    player.drinksSold++;

                    player.wallet.totalProfit += player.recipe.price;

                    //{
                    //    Console.WriteLine("Not enough cups...Run out of cups!!!");
                    //}
                }
                else
                {
                    Console.WriteLine("Sold out!");
                }
            }
        }
        public void DisplayActualWether()
        {
            Console.WriteLine($"\nToday weather was {days[currentDay - 1].weather.condition}, temperature {days[currentDay - 1].weather.temperature} ");
        }
        
        public void DisplayProfitLoss()// hsould have Player player in here in case we have two players
        {
            Console.WriteLine($"\nDay {currentDay} is over! You sold {player.drinksSold} cups, which brought in ${player.drinksSold * player.recipe.price}");
        }

        public void GameResuts()
        {
            Console.WriteLine($"\nThe week is over. Your total profit is {player.wallet.totalProfit}");
        }

        public void GameSimulation()
        {
            while(currentDay < 8)
            {
                player.drinksSold = 0;

                Console.WriteLine($"\nDay {currentDay} begins!");

                player.DisplayInvetory();
                DisplayPrices();
                store.SellItems(player);
                player.DisplayInvetory();

                days[currentDay - 1].weather.DisplayTemperature();

                player.recipe.DisplayRecipe();
                player.recipe.ChangeRecipe();
                
                player.MakeAPitcher(UserInterface.GetNumberOfPitchers());

                WeatherChanger();

                CustomerPurchase();

                DisplayActualWether();

                DisplayProfitLoss();
                player.drinksAvailable = 0;
                currentDay++;
            }
        }

        public void RunGame()
        {
            Welcome();
            GameSimulation();
            GameResuts();
        }

    }
}
