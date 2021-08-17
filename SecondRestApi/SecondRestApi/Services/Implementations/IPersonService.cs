using SecondRestApi.Model;
using System.Collections.Generic;

namespace SecondRestApi.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        void Delete(long id);
        Person Update(Person person);
    }
}
