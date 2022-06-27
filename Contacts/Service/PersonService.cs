<<<<<<< HEAD
﻿using Contacts.Model;
using Contacts.Repository;
=======
﻿using Contacts.Controller.util;
using Contacts.Model;
using Contacts.Repository;
using Contacts.Service.util;
>>>>>>> real-feauture2
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
<<<<<<< HEAD
            return db.Persons.Find(id);
        }

        public IEnumerable<Person> findAll()
        {
            return db.Persons.ToList();
        }

=======
            if (!db.Persons.Any(p => p.id == id))
                throw new KeyNotFoundException($"No person with id:{id}");
            return db.Persons.Find(id);
        }

>>>>>>> real-feauture2
        public IEnumerable<Person> findAllAndSort(PersonSortState state)
        {
            var result = db.Persons.ToList();
            result = state switch
            {
                PersonSortState.birthdayAscending => result.OrderBy(p => p.birthday).ToList(),
                PersonSortState.birthdayDescending => result.OrderByDescending(p => p.birthday).ToList(),
                PersonSortState.firstNameAscending => result.OrderBy(p => p.firstName).ToList(),
                PersonSortState.firstNameDescending => result.OrderByDescending(p => p.firstName).ToList(),
                PersonSortState.lastNameAscending => result.OrderBy(p => p.lastName).ToList(),
                PersonSortState.lastNameDescending => result.OrderByDescending(p => p.lastName).ToList(),
                PersonSortState.middleNameAscending => result.OrderBy(p => p.middleName).ToList(),
                PersonSortState.middleNameDescending => result.OrderByDescending(p => p.middleName).ToList(),
                PersonSortState.placeOfStudyAscending => result.OrderBy(p => p.placeOfStudy).ToList(),
                PersonSortState.placeOfStudyDescending => result.OrderBy(p => p.placeOfStudy).ToList(),
                PersonSortState.workplaceAscending => result.OrderBy(p => p.workplace).ToList(),
                PersonSortState.workplaceDescending => result.OrderBy(p => p.workplace).ToList(),
                _ => result.OrderBy(p => p.firstName).ToList(),
            };
            return result;
        }

        public IEnumerable<Person> find(Person person)
        {
            var persons = db.Persons.Where(p =>
            ((person.firstName == null || person.firstName.ToLower() == p.firstName.ToLower())
            && (person.id == null || person.id == p.id)
            && (person.lastName == null || person.lastName.ToLower() == p.lastName.ToLower())
            && (person.middleName == null || person.lastName.ToLower() == p.lastName.ToLower())
            && (person.address == null || person.address.ToLower() == p.address.ToLower())
            && (person.discord == null || person.discord.ToLower() == p.discord.ToLower())
            && (person.birthday == default(DateTime) || person.birthday == p.birthday)
            && (person.VKLink == null || person.VKLink.ToLower() == p.VKLink.ToLower())
            && (person.Email == null || person.Email.ToLower() == p.Email.ToLower())
            && (person.placeOfStudy == null || person.placeOfStudy.ToLower() == p.placeOfStudy.ToLower())
            && (person.workplace == null || person.workplace.ToLower() == p.workplace.ToLower())
            && (person.phoneNumber == null || person.phoneNumber.ToLower() == p.phoneNumber.ToLower())
            && (person.sex == default(Sex) || person.sex == p.sex)
            )).ToList();
            return persons;
        }
        


<<<<<<< HEAD
        public Person update(Person person)
        {
=======
        public Person update(UpdatingPersonArgument argument)
        {
            if (!db.Persons.Any(p => p.id == argument.id))
                throw new KeyNotFoundException($"No person with id:{argument.id}");

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
>>>>>>> real-feauture2
            var result = db.Update(person).Entity;
            db.SaveChanges();
            return result;
        }

<<<<<<< HEAD
        public void delete(int? id)
        {
=======
        public void deleteById(int? id)
        {
            if (!db.Persons.Any(p => p.id == id))
                throw new KeyNotFoundException($"No person with id:{id}");
>>>>>>> real-feauture2
            db.Persons.Remove(find(id));
            db.SaveChanges();
        }

    }
}
