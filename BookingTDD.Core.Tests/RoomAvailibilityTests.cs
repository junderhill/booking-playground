using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            new object[] {BookingPeriod, new BookingPeriod(new DateTime(2018,1,1,9,0,0), new DateTime(2018,1,1,10,15,00))}, 
            new object[] {BookingPeriod, new BookingPeriod(new DateTime(2018,1,1,9,0,0), new DateTime(2018,1,1,15,0,00))}, 
            new object[] {BookingPeriod, new BookingPeriod(new DateTime(2018,1,1,10,50,0), new DateTime(2018,1,1,15,0,00))}, 
            new object[] {BookingPeriod, new BookingPeriod(new DateTime(2018,1,1,10,15,0), new DateTime(2018,1,1,10,30,00))}, 
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
        
        public static IEnumerable<object[]> AcceptableBookings => new[]
        {
            new object[] {BookingPeriod, new BookingPeriod(new DateTime(2018,1,1,9,0,0), new DateTime(2018,1,1,10,00,00))}, 
            new object[] {BookingPeriod, new BookingPeriod(new DateTime(2018,1,1,14,0,0), new DateTime(2018,1,1,15,0,00))}, 
            new object[] {BookingPeriod, new BookingPeriod(new DateTime(2018,1,2,10,50,0), new DateTime(2018,1,2,15,0,00))}, 
            new object[] {BookingPeriod, new BookingPeriod(new DateTime(2017,1,1,10,15,0), new DateTime(2017,1,1,10,30,00))}, 
        };
        
        [Theory]
        [MemberData(nameof(AcceptableBookings))]
        public void ShouldBeAvailibleIfTheyDontOverLap(BookingPeriod toCreate, BookingPeriod existing)
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
            result.ShouldBeTrue();

        }


        private static Room CreateRoom(List<Booking> bookings)
        {
            var room = new Room(1, "Conference Room", 100) {Bookings = bookings};
            return room;
        }
    }
}