using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Domain.Contracts
{
    public interface IPersonRepository
    {
         Task<Person> GetByName(Name name);

         Task<Person> GetByAge(string age);

         Task<IEnumerable<Person>> GetList();

         Task Add(Person person);

         void Update(Person person);

         void Remove(Person person);
    }
}