using System;

namespace condofy_challenge.Funtions
{
    public static class StringFunctions
    {
        public static TimeSpan StringToTime(this string _hour)
        {
            if (!Validates.TimerValidate.isHour(_hour))
                return new TimeSpan();
            return TimeSpan.Parse(_hour);
        } 
    }
}
