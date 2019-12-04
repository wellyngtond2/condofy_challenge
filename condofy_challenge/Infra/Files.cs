using condofy_challenge.Funtions;
using condofy_challenge.Validates;
using System;
using System.Collections.Generic;
using System.IO;

namespace condofy_challenge.Infra
{
    public static class Files
    {
        public static string GetFilePath() => $@"{Directory.GetCurrentDirectory()}\Data\restaurant-hours.csv";

        public static List<string> GetAvailableRestaurant(string hour)
        {
            if (!hour.isHour())
                return new List<string>();

            TimeSpan _hour = hour.StringToTime();
            string line;
            bool firstRead = true;
            List<string> restaurants = new List<string>();

            using (var fs = File.OpenRead(Files.GetFilePath()))
            using (var stream = new StreamReader(fs))
                while ((line = stream.ReadLine()) != null)
                {
                    if (firstRead) { firstRead = false; continue; }
                    string rest = addRestaurant(line, _hour);
                    if (rest.Length > 0)
                        restaurants.Add(rest);
                }

            return restaurants;
        }

        public static string addRestaurant(string line, TimeSpan hour)
        {
            if (string.IsNullOrEmpty(line))
                return "";

            string[] restaurantHourAvailable = new string[2];
            string[] restaurantHour = new string[2];
            restaurantHourAvailable = line.Split(',');
            restaurantHour = restaurantHourAvailable[1].Split('-');

            if (string.IsNullOrEmpty(restaurantHourAvailable[0]))
                return "";

            if (HourIsBetween(hour, restaurantHour))
                return restaurantHourAvailable[0].ToString() + ",";
            else
                return "";
        }

        private static bool HourIsBetween(TimeSpan hour, string[] restaurantHour)
        {
            if (string.IsNullOrEmpty(restaurantHour[0]) || string.IsNullOrEmpty(restaurantHour[1]))
                return false;

            return hour >= TimeSpan.Parse(restaurantHour[0]) && hour <= TimeSpan.Parse(restaurantHour[1]);
        }
    }
}
