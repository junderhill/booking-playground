using System.Collections.Generic;
using System.Linq;

namespace BookingTDD.Core.Domain
{
    public class Room : IRoom
    {
        public Room(int id, string description, int capacity)
        {
            Id = id;
            Description = description;
            Capacity = capacity;
        }

        public int Id { get; private set; }
        public int Capacity { get; private set; }
        public string Description { get; private set; }
        public List<Booking> Bookings { get; set; }

        public bool IsAvailable(BookingPeriod requestedBookingPeriod)
        {
            return !Bookings.Any(b => b.BookingPeriod.OverlappedBy(requestedBookingPeriod));
        }
    }
}