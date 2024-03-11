using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Commons.Valueobjects
{
    internal class Address : ValueObject
    {
        public string? StreetAvenue { get; private set; }
        public string? District { get; private set; }
        public string? Complement { get; private set; }
        public string? City { get; private set; }
        public string? State { get; private set; }
        public string? UF { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
