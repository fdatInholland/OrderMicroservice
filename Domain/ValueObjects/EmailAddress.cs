using ValueOf;

namespace OrderMicroservice.Domain.ValueObjects
{
    public class EmailAddress : ValueOf<string, EmailAddress>
    {
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value) || !Value.Contains("@"))
            {
                throw new ArgumentException("Invalid email address.");
            }
        }
    }
}
