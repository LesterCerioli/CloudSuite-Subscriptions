using NetDevPack.Domain;

namespace CloudSuite.Modules.Commons.Valueobjects
{
    public class Name : ValueObject
    {
        private string? name;

        public Name(string? name)
        {
            this.name = name;
        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}