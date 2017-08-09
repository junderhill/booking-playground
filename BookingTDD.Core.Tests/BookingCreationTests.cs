using System;
using BookingTDD.Core.Domain;
using BookingTDD.Core.Exceptions;
using Moq;
using Xunit;
using Should;

namespace BookingTDD.Core.Tests
{
    public class BookingCreationTests
    {
        private static readonly DateTime BookingDate = new DateTime(2018, 01, 01, 10, 00, 00);

        [Fact]
        public void CanCreateABookingIfTheRoomIsAvailible()
        {
            //arrange
            var room = GetMockRoomWhereIsAvailibleEquals(true);
            //act
            var booking = Booking.Create(new BookingPeriod(BookingDate, BookingDate.AddHours(2)), room.Object);
            //assert
            booking.ShouldNotBeNull();
        }


        [Fact]
        public void ShouldThrowRoomNotAvailableExceptionIfNotAvailable()
        {
            //arrange
            var room = GetMockRoomWhereIsAvailibleEquals(false);
            
            //act
            var exception = Record.Exception(() => { 
                Booking.Create(new BookingPeriod(BookingDate, BookingDate.AddHours(2)), room.Object);
            });
            //assert
            exception.ShouldNotBeNull();
            exception.ShouldBeType<RoomNotAvailableException>();
        }
        
        private static Mock<IRoom> GetMockRoomWhereIsAvailibleEquals(bool roomIsAvailible)
        {
            var room = new Mock<IRoom>();
            room.Setup(r => r.IsAvailable(It.IsAny<BookingPeriod>())).Returns(roomIsAvailible);
            return room;
        }
    }
}