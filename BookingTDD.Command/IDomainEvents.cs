using System.Collections.Generic;

namespace BookingTDD.Command
{
    public interface IDomainEvents
    {
        void PublishEvent<T>(T obj) where T : BaseEvent;
    }

    public class DomainEvents : IDomainEvents
    {
        private Queue<BaseEvent> events;

        public DomainEvents()
        {
            events = new Queue<BaseEvent>();
        }

        public void PublishEvent<T>(T obj) where T : BaseEvent
        {
            this.events.Enqueue(obj);
        }
    }
}