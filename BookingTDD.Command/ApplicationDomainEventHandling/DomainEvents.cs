using System;
using System.Collections.Concurrent;
using System.Threading;

namespace BookingTDD.Command
{
    public class DomainEvents : IDomainEvents
    {
        private readonly ISendEmail _sendEmail;
        private readonly BlockingCollection<BaseEvent> _events;
        

        public DomainEvents(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
            _events = new BlockingCollection<BaseEvent>();
            new Thread(ConsumeLoop).Start();
        }

        private void ConsumeLoop()
        {
            while (true)
            {
                try
                {
                    var item = _events.Take();
                    item.Handle();
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        public void PublishEvent<T>(T obj) where T : BaseEvent
        {
            this._events.Add(obj);
        }
    }
}