using ValueOf;

namespace OrderMicroservice.Domain.ValueObjects
{
    public class Address : ValueOf<(string Street, string City, string Zip), Address>
    {
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value.Street))
            {
                throw new ArgumentException("Street cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(Value.City))
            {
                throw new ArgumentException("City cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(Value.Zip))
            {
                throw new ArgumentException("Zip code cannot be empty.");
            }
        }
    }
}
