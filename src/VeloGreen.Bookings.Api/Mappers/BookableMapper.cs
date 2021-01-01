using System;
using VeloGreen.Bookings.Api.Entities;
using VeloGreen.Bookings.Api.Helpers;

namespace VeloGreen.Bookings.Api.Mappers
{
    public static class BookableMapper
    {
        public static Bookable MapToBookable(BookableCreateRequest request)
        {
            return new()
            {
                Id = Guid.Empty,
                Name = request.Name,
                From = request.From ?? ApplicationTime.UtcNow(),
                To = request.To ?? DateTime.MaxValue,
                Foresight = request.Foresight,
                StartInterval = request.StartInterval,
                DaysAndTimes = request.DaysAndTimes,
                NonBookableDays = request.NonBookableDays,
            };
        }
    }
}
