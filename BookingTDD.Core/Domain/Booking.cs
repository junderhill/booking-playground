using System;
using System.Runtime.CompilerServices;
using BookingTDD.Core.Exceptions;

[assembly:InternalsVisibleTo("BookingTDD.Core.Tests")]
namespace BookingTDD.Core.Domain
{
    public class Booking
    {
        
        internal Booking(BookingPeriod bookingPeriod, IRoom room)
        {
            Room = room;
            BookingPeriod = bookingPeriod;
        }

        public int Id { get; private set; }
        public BookingPeriod BookingPeriod { get; private set; }
        public IRoom Room { get; private set; }

        public static Booking Create(BookingPeriod bookingPeriod, IRoom room)
        {
            if (!room.IsAvailable(bookingPeriod))
                throw new RoomNotAvailableException();
                
            var booking = new Booking(bookingPeriod, room);
            return booking;
        }
    }
}