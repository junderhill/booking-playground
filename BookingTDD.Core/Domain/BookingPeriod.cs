﻿using System;

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

        public bool OverlappedBy(BookingPeriod otherPeriod)
        {
            if (Start >= otherPeriod.End)
                return false;
            if (otherPeriod.Start >= End)
                return false;

            return true;
        }
    }
}