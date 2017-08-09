using System;

namespace BookingTDD.Core.Domain
{
    public struct BookingPeriod
    {
        public BookingPeriod(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}