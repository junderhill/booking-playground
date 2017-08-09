namespace BookingTDD.Command.Handlers
{
    public abstract class BaseHandler
    {
        protected readonly IDomainEvents DomainEvents;

        protected BaseHandler(IDomainEvents domainEvents)
        {
            DomainEvents = domainEvents;
        }
    }
}