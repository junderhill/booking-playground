using BookingTDD.Core.Domain;

namespace BookingTDD.Command.Events
{
    public class BookingCreatedEvent : BaseEvent
    {
        private readonly Booking _booking;

        public BookingCreatedEvent(Booking booking)
        {
            _booking = booking;
        }

        public override void Handle()
        {
        }
    }
}