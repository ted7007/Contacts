
﻿using Contacts.Controller.Mapper;
using Contacts.Controller.util;
using Contacts.DTO;
using Contacts.Service;
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

        private IPersonMapper mapper;

        public PersonController(IPersonService service, IPersonMapper mapper)
        {
            db = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult findAll(PersonSortState sortState)
        {
            
            var result = new List<PersonDTO>();
            db.findAllAndSort(sortState).ToList().ForEach(p => result.Add(mapper.EntityToDTO(p)));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult find(int id)
        {
            return Ok(mapper.EntityToDTO(db.find(id)));
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
            var entity = db.find(mapper.DTOToEntity(dto));
            entity.ToList().ForEach(p => result.Add(mapper.EntityToDTO(p)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult create(PersonDTO dto)
        {
            return Ok(mapper.EntityToDTO(db.create(mapper.DTOToCreationArgument(dto))));
        }

        [HttpPut]
        public IActionResult update(PersonDTO dto)
        {

            return Ok(db.update(mapper.DTOToUpdatingArgument(dto)));
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int? id)
        {
            db.deleteById(id);
            return Ok();
        }
    }
}
