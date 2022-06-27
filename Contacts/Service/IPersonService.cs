<<<<<<< HEAD
﻿using Contacts.Model;
=======
﻿using Contacts.Controller.util;
using Contacts.Model;
using Contacts.Service.util;
>>>>>>> real-feauture2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Service
{
    public interface IPersonService
    {
<<<<<<< HEAD
        public IEnumerable<Person> findAll();
=======
>>>>>>> real-feauture2

        public IEnumerable<Person> findAllAndSort(PersonSortState state);

        public Person find(int? id);

        public IEnumerable<Person> find(Person person);

        public Person create(CreationPersonArgument argument);

<<<<<<< HEAD
        public Person update(Person person);

        public void delete(int? id);
=======
        public Person update(UpdatingPersonArgument person);

        public void deleteById(int? id);
>>>>>>> real-feauture2
    }
}
