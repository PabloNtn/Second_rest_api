using SecondRestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SecondRestApi.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                object person = MockPerson(i);
                persons.add(person)
            }
            return persons;
        }

        

        public Person FindeById(long id)
        {
            return new Person
            {
                id = IncrementAndGet(),
                FirstName = "Pablo",
                LastName = "Monteiro",
                Adress = "Rua catatau",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private object MockPerson(int i)
        {
            return new Person
            {
                id = IncrementAndGet(),
                FirstName = "Person Name",
                LastName = "Person LastName",
                Adress = "Some Adress",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
