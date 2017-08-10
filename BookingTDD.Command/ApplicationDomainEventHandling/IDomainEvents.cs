namespace BookingTDD.Command
{
    public interface IDomainEvents
    {
        void PublishEvent<T>(T obj) where T : BaseEvent;
    }
}