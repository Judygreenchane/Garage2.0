namespace Garage2._0.Helper
{
    public class ParkingHelper  
    {
        public const decimal ParkingRate = 0.5m; // Amount per minute

        public static string FormatTimeSpan(TimeSpan timeSpan)
        {
            if (timeSpan.Days == 00 && timeSpan.Hours == 0)
            {
                return $"{timeSpan.Minutes} minutes";
            } 
            else if (timeSpan.Days == 0)
            {
                return $"{timeSpan.Hours} hours {timeSpan.Minutes} minutes";
            }
            else
            {
                return $"{timeSpan.Days} days {timeSpan.Hours} hours {timeSpan.Minutes} minutes";
            }
        }

        public static decimal ParkingFee(DateTime arrival, DateTime departure)
        {
            decimal fee = Math.Round((decimal)(departure-arrival).TotalMinutes*ParkingRate, 2);
            return fee;
        }
    }
}
