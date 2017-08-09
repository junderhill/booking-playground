using System;
using System.Collections.Generic;
using BookingTDD.Core.Domain;

namespace BookingTDD.Core
{
    public class Room
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

        public bool IsAvailable(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}