using condofy_challenge.Infra;
using System;
using System.Collections.Generic;

namespace condofy_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputHour = Console.ReadLine();
            List<string> restaurantes = Files.GetAvailableRestaurant(inputHour);
            PrintAvaileblesRestaurants(restaurantes);

            Console.ReadKey();
        }

        private static void PrintAvaileblesRestaurants(List<string> restaurantes)
        {
            foreach (var rest in restaurantes)
                Console.Write(string.Format("{0}\n", rest));
        }
    }
}