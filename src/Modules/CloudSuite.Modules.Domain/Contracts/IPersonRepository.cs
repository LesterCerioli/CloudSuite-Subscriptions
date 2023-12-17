using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Domain.Contracts
{
    public interface IPersonRepository
    {
         Task<Person> GetByName(string name);

         Task<Person> GetByAge(string age);

         Task<IEnumerable<Person>> GetList();

         Task Add(Person person);

         void update(Person person);

         void Remove(Person person);
    }
}