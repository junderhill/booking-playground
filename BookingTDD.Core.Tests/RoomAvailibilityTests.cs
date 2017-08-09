using System;
using System.Collections.Generic;
using BookingTDD.Core.Domain;
using Should;
using Xunit;

namespace BookingTDD.Core.Tests
{
    public class RoomAvailibilityTests
    {
        private static readonly BookingPeriod BookingPeriod = new BookingPeriod(new DateTime(2018,01,01,10,00,00), new DateTime(2018,1,1,11,00,00));


        [Fact]
        public void ShouldBeAvailibleIfThereAreNoOtherBookings()
        {
            //arrange
            var bookings = new List<Booking>();
            var room = CreateRoom(bookings);
            //act
            var result = room.IsAvailable(BookingPeriod);
            //assert
            result.ShouldBeTrue();
        }

        public static IEnumerable<object[]> OverlappingBookings => new[]
        {
            new object[] {BookingPeriod, BookingPeriod}, 
        };

        [Theory]
        [MemberData(nameof(OverlappingBookings))]
        public void ShouldNotBeAvailibleIfTheyOverLap(BookingPeriod toCreate, BookingPeriod existing)
        {
            //arrange
            var bookings = new List<Booking>()
            {
                new Booking(existing, null)
            };
            var room = CreateRoom(bookings);
            //act
            var result = room.IsAvailable(toCreate);
            //assert
            result.ShouldBeFalse();

        }

        private static Room CreateRoom(List<Booking> bookings)
        {
            var room = new Room(1, "Conference Room", 100) {Bookings = bookings};
            return room;
        }
    }
}