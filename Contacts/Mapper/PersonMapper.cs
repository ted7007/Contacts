using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.DTO;
using Contacts.Model;

namespace Contacts.Mapper
{
    public class PersonMapper
    {
        
        public CreationPersonArgument DTOToCreationArgument(PersonDTO dto)
        {
            var result = new CreationPersonArgument()
            {
                firstName = dto.firstName,
                lastName = dto.lastName,
                middleName = dto.middleName,
                phoneNumber = dto.phoneNumber,
                Email = dto.email,
                placeOfStudy = dto.placeOfStudy,
                discord = dto.discord,
                address = dto.address,
                birthday = dto.birthday,
                VKLink = dto.VKLink,
                workplace = dto.workplace

            };
            Sex sex = Sex.BattleHelicopter;
            switch (dto.sex)
            {
                case "Male":
                    sex = Sex.Male;
                    break;
                case "Female":
                    sex = Sex.Female;
                    break;
                case "Batle Helicopter":
                    sex = Sex.BattleHelicopter;
                    break;
            }
            result.sex = sex;
            return result;

        }

        public Person DTOToEntity(PersonDTO dto)
        {
            var result = new Person()
            {
                id = dto.id,
                firstName = dto.firstName,
                lastName = dto.lastName,
                middleName = dto.middleName,
                phoneNumber = dto.phoneNumber,
                Email = dto.email,
                placeOfStudy = dto.placeOfStudy,
                discord = dto.discord,
                address = dto.address,
                birthday = dto.birthday,
                VKLink = dto.VKLink,
                workplace = dto.workplace

            };
            Sex sex = Sex.BattleHelicopter;
            switch (dto.sex)
            {
                case "Male":
                    sex = Sex.Male;
                    break;
                case "Female":
                    sex = Sex.Female;
                    break;
                case "Battle Helicopter":
                    sex = Sex.BattleHelicopter;
                    break;
            }
            result.sex = sex;
            return result;
        }
        
        public PersonDTO EntityToDTO(Person person)
        {
            var result = new PersonDTO()
            {
                id = person.id,
                firstName = person.firstName,
                lastName = person.lastName,
                middleName = person.middleName,
                phoneNumber = person.phoneNumber,
                email = person.Email,
                placeOfStudy = person.placeOfStudy,
                discord = person.discord,
                address = person.address,
                birthday = person.birthday,
                VKLink = person.VKLink,
                workplace = person.workplace

            };
            string sex = "";
            switch(person.sex)
            {
                case Sex.Male:
                    sex = "Male";
                    break;
                case Sex.Female:
                    sex = "Female";
                    break;
                case Sex.BattleHelicopter:
                    sex = "Battle Helicopter";
                    break;
            }
            result.sex = sex;
            return result;
        }

        public PersonSortState stringToPersonSortState(string value)
        {
            PersonSortState result = value switch
            {
                "firstNameAscending" => result = PersonSortState.firstNameAscending,
                "firstNameDescending" => result = PersonSortState.firstNameDescending,
                "lastNameAscending" => result = PersonSortState.lastNameAscending,
                "lastNameDescending" => result = PersonSortState.lastNameDescending,
                "middleNameAscending" => result = PersonSortState.middleNameAscending,
                "middleNameDescending" => result = PersonSortState.middleNameDescending,
                "birthdayAscending" => result = PersonSortState.birthdayAscending,
                "birthdayDescending" => result = PersonSortState.birthdayDescending,
                "placeOfStudyAscending" => result = PersonSortState.placeOfStudyAscending,
                "placeOfStudyDescendin" => result = PersonSortState.placeOfStudyDescending,
                "workplaceAscending" => result = PersonSortState.workplaceAscending,
                "workplaceDescending" => result = PersonSortState.workplaceDescending,
                _ => result = PersonSortState.firstNameAscending
            };
            return result;
        }
    }
}
