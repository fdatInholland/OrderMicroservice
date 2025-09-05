namespace OrderMicroservice.Domain.Interfaces
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
