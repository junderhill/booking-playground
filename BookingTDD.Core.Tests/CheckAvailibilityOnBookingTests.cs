using System;
using System.Collections.Generic;
using BookingTDD.Core.Domain;
using BookingTDD.Core.Exceptions;
using Xunit;
using Should;

namespace BookingTDD.Core.Tests
{
    public class CheckAvailibilityOnBookingTests
    {
        private static readonly DateTime BookingDate = new DateTime(2018, 01, 01, 10, 00, 00);

        [Fact]
        public void ShouldSucceedIfBookingRoomAvailable()
        {
            //arrange
            var room = new Room(1,"Conference room", 100);
            //act
            var booking = Booking.Create(BookingDate, BookingDate.AddHours(2), room);
            //assert
            booking.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldThrowRoomNotAvailableExceptionIfNotAvailable()
        {
            //arrange
            var room = new Room(1, "Conference room", 100);
            room.Bookings = new List<Booking>()
            {
                new Booking(BookingDate, BookingDate.AddHours(2), room)
            };
            //act
            var exception = Record.Exception(() => { 
                Booking.Create(BookingDate, BookingDate.AddHours(2), room);
            });
            //assert
            exception.ShouldNotBeNull();
            exception.ShouldBeType<RoomNotAvailableException>();
        }
    }
}