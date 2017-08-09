namespace BookingTDD.Core.Domain
{
    public interface IRoom
    {
        bool IsAvailable(BookingPeriod bookingPeriod);
    }
}