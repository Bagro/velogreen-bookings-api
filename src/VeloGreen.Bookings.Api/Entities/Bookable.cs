using System;
using System.Collections.Generic;
using VeloGreen.Bookings.Api.Types;

namespace VeloGreen.Bookings.Api.Entities
{
    public class Bookable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public List<DayAndTimes> DaysAndTimes { get; set; }

        public int Foresight { get; set; }

        public StartInterval StartInterval { get; set; }

        public List<DateTime> NonBookableDays { get; set; }
    }
}
