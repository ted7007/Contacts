using Contacts.Model;
using Contacts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Service
{
    public class PersonService : IPersonService
    {
        private PersonContext db;

        public PersonService(PersonContext context)
        {
            db = context;
        }

        public Person create(CreationPersonArgument argument)
        {
            Person person = new Person()
            {
                firstName = argument.firstName,
                lastName = argument.lastName,
                middleName = argument.middleName,
                phoneNumber = argument.phoneNumber,
                Email = argument.Email,
                placeOfStudy = argument.placeOfStudy,
                discord = argument.discord,
                address = argument.address,
                birthday = argument.birthday,
                sex = argument.sex,
                VKLink = argument.VKLink,
                workplace = argument.workplace
            };
            var result = db.Add(person).Entity;
            db.SaveChanges();
            return result;
        }

        public Person find(int? id)
        {
            return db.Persons.Find(id);
        }

        public IEnumerable<Person> findAll()
        {
            return db.Persons.ToList();
        }

        public Person update()
        {
            throw new NotImplementedException();
        }
    }
}
