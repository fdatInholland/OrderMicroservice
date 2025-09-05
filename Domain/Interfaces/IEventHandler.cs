namespace OrderMicroservice.Domain.Interfaces
{
    public interface IEventHandler <TEvent> where TEvent : IDomainEvent
    {
    }
}
