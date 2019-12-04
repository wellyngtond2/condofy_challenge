using condofy_challenge.Handlers;
using System.Text.RegularExpressions;

namespace condofy_challenge.Validates
{
    public static class TimerValidate
    {
        public static bool isHour(this string time)
        {
            if (string.IsNullOrEmpty(time))
                return false;

            if (!new Regex("^(0[0-9]|1[0-9]|2[0-3]|[0-9]):[0-5][0-9]$").IsMatch(time))
            {
                ExceptionsHandler.print("Time is invalid format");
                return false;
            }
            return true;
        }
    }
}