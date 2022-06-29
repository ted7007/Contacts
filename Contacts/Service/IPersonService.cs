using Contacts.Controller.util;
using Contacts.Model;
using Contacts.Service.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Service
{
    public interface IPersonService
    {

        public IEnumerable<Person> findAllAndSort(PersonSortState state);

        public Person find(int? id);

        public IEnumerable<Person> find(Person person);

        public Person create(CreationPersonArgument argument);

        public Person update(UpdatingPersonArgument person);

        public void deleteById(int? id);

    }
}
