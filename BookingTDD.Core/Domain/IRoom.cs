using System;

namespace BookingTDD.Core.Domain
{
    public interface IRoom
    {
        bool IsAvailable(DateTime start, DateTime end);
    }
}