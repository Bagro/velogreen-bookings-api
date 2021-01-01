using System;

namespace VeloGreen.Bookings.Api.Helpers
{
    public static class ApplicationTime
    {
        private static DateTime _dateTime = DateTime.MinValue;
        
        public static void Set(DateTime customDateTime) => _dateTime = customDateTime;

        public static void Reset() => _dateTime = DateTime.MinValue;

        public static DateTime Now() => _dateTime == DateTime.MinValue ? DateTime.Now : _dateTime;
        
        public static DateTime UtcNow() => _dateTime == DateTime.MinValue ? DateTime.UtcNow : _dateTime;
        
    }
}
