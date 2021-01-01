using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using VeloGreen.Bookings.Api.Controllers;
using VeloGreen.Bookings.Api.Entities;
using VeloGreen.Bookings.Api.Handlers;
using VeloGreen.Bookings.Api.Helpers;
using VeloGreen.Bookings.Api.Types;
using Xunit;

namespace VeloGreen.Bookings.Api.Tests.Controllers
{
    public class ManageControllerTests
    {
        private readonly ManageController _manageController;
        private readonly IBookableHandler _bookableHandler;

        public ManageControllerTests()
        {
            ApplicationTime.Set(new DateTime(2021, 1, 1));

            _bookableHandler = Substitute.For<IBookableHandler>();
            _manageController = new ManageController(_bookableHandler);
        }

        [Fact]
        public async Task CreateBookable_NormalRollingBookableValidData_ShouldCallHandler()
        {
            Bookable expectedBookable = new()
            {
                Id = Guid.Empty,
                Name = "Test name",
                From = ApplicationTime.UtcNow(),
                To = DateTime.MaxValue,
                DaysAndTimes = new List<DayAndTimes>()
                {
                    new()
                    {
                        Day = DayOfWeek.Monday,
                        Time = new FromToTime
                        {
                            From = new Time
                            {
                                Hour = 10,
                                Minute = 0,
                            },
                            To = new Time
                            {
                                Hour = 18,
                                Minute = 0,
                            },
                        },
                        NonBookableTime = new FromToTime
                        {
                            From = new Time
                            {
                                Hour = 13,
                                Minute = 0,
                            },
                            To = new Time
                            {
                                Hour = 13,
                                Minute = 30,
                            },
                        }
                    },
                },
                Foresight = 24,
                StartInterval = StartInterval.Fifteen,
                NonBookableDays = null,
            };

            BookableCreateRequest createRequest = new()
            {
                Name = "Test name",
                DaysAndTimes = new List<DayAndTimes>()
                {
                    new()
                    {
                        Day = DayOfWeek.Monday,
                        Time = new FromToTime
                        {
                            From = new Time
                            {
                                Hour = 10,
                                Minute = 0,
                            },
                            To = new Time
                            {
                                Hour = 18,
                                Minute = 0,
                            },
                        },
                        NonBookableTime = new FromToTime
                        {
                            From = new Time
                            {
                                Hour = 13,
                                Minute = 0,
                            },
                            To = new Time
                            {
                                Hour = 13,
                                Minute = 30,
                            },
                        }
                    },
                },
                Foresight = 24,
                StartInterval = StartInterval.Fifteen,
            };

            Bookable actual = null;

            _bookableHandler.Create(Arg.Do<Bookable>(x => actual = x));
            await _manageController.CreateBookable(createRequest);

            await _bookableHandler.Received(1).Create(Arg.Any<Bookable>());
            
            actual.Should().BeEquivalentTo(expectedBookable);
        }
    }
}
