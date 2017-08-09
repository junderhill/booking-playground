using BookingTDD.Core.Domain;

namespace BookingTDD.Core.RepositoryContracts
{
    public interface IBookingRepository
    {
        void CreateBooking(Booking booking);
    }
}