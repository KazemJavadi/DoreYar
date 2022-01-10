namespace WebApp.Helpers
{
    public static class TimeHelper
    {
        public static string GetTimeStamp(DateTime dateTime) => new DateTimeOffset(dateTime).ToUnixTimeMilliseconds().ToString();
        public static string GetTimeStampNow() => GetTimeStamp(DateTime.Now);
    }
}
