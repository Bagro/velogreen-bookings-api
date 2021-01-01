using System;

namespace VeloGreen.Bookings.Api.Entities
{
    public class DayAndTimes
    {
        public DayOfWeek Day { get; set; }
        
        public FromToTime Time { get; set; }
        
        public FromToTime NonBookableTime { get; set; }
    }
}
