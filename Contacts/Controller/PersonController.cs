
﻿using Contacts.Controller.Mapper;
using Contacts.Controller.util;
using Contacts.DTO;
using Contacts.Model;
using Contacts.Service;
using Contacts.Service.util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService db;

        private IMapper mapper;

        public PersonController(IPersonService service, IMapper mapper)
        {
            db = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult findAll(PersonSortState sortState)
        {
            
            var result = new List<PersonDTO>();
            db.findAllAndSort(sortState).ToList().ForEach(p => result.Add(mapper.Map<Person, PersonDTO>(p)));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult find(int id)
        {
            return Ok(mapper.Map<Model.Person, PersonDTO>(db.find(id)));
        }

        [HttpGet("find")]
        public ActionResult find(
            int? id, string firstName, string lastName, string middleName, string sex, DateTime birthday,
            string email, string VKLink, string discord, string address, string placeOfStudy, string workplace)
        {
            var dto = new PersonDTO()
            {
                id = id,
                firstName = firstName,
                lastName = lastName,
                middleName = middleName,
                sex = sex,
                birthday = birthday,
                email = email,
                VKLink = VKLink,
                discord = discord,
                address = address,
                placeOfStudy = placeOfStudy,
                workplace = workplace
            };
            List<PersonDTO> result = new List<PersonDTO>();
            var entity = db.find(mapper.Map<PersonDTO, Model.Person>(dto));
            entity.ToList().ForEach(p => result.Add(mapper.Map<Person, PersonDTO>(p)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult create(PersonDTO dto)
        {
            
            return Ok(mapper.Map<Person, PersonDTO>(db.create(mapper.Map<PersonDTO, CreationPersonArgument>(dto))));
        }

        [HttpPut]
        public IActionResult update(PersonDTO dto)
        {

            return Ok(db.update(mapper.Map<PersonDTO, UpdatingPersonArgument>(dto)));
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int? id)
        {
            db.deleteById(id);
            return Ok();
        }
    }
}
