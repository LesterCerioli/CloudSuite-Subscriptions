using NetDevPack.Domain;

namespace CloudSuite.Commons.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
        
    }
}