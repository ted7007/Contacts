﻿using Contacts.DTO;
using Contacts.Model;
using Contacts.Service.util;

namespace Contacts.Controller.Mapper
{
    public interface IPersonMapper
    {
        public CreationPersonArgument DTOToCreationArgument(PersonDTO dto);

        public UpdatingPersonArgument DTOToUpdatingArgument(PersonDTO dto);

        public Person DTOToEntity(PersonDTO dto);

        public PersonDTO EntityToDTO(Person person);
    }
}