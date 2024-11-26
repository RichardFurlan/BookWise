namespace BookWise.Application.Helpers;

public static class DateTimeHelper
{
    private const string BrasiliaTimeZoneId = "E. South America Standard Time";
    
    public static DateTime ConvertToBrasiliaTime(DateTime utcDateTime)
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(BrasiliaTimeZoneId);
        return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
    }
}