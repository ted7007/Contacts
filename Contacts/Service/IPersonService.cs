using Contacts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Service
{
    public interface IPersonService
    {
        public IEnumerable<Person> findAll();

        public Person find(int? id);

        public IEnumerable<Person> find(Person person);

        public Person create(CreationPersonArgument argument);

        public Person update(Person person);

        public void delete(int? id);
    }
}
