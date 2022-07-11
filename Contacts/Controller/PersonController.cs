
﻿using Contacts.Controller.Mapper;
using Contacts.Controller.util;
using Contacts.DTO;
using Contacts.Model;
using Contacts.Service;
using Contacts.Service.util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private IPersonService service;

        private IMapper mapper;

        private ILogger logger;

        public PersonController(IPersonService service, IMapper mapper, ILogger<PersonController> logger)
        {
            this.service = service;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult findAll(PersonSortState sortState)
        {
            
            var result = new List<PersonDTO>();
            service.findAllAndSort(sortState).ToList().ForEach(p => result.Add(mapper.Map<Person, PersonDTO>(p)));
            logger.LogInformation($"request for findAll with parametres: sortState={ sortState}");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult find(int id)
        {
            logger.LogInformation($"request for find with parametres: id={id}");
            return Ok(mapper.Map<Model.Person, PersonDTO>(service.find(id)));
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
                vkLink = VKLink,
                discord = discord,
                address = address,
                placeOfStudy = placeOfStudy,
                workplace = workplace
            };
            List<PersonDTO> result = new List<PersonDTO>();
            var entity = service.find(mapper.Map<PersonDTO, Model.Person>(dto));
            entity.ToList().ForEach(p => result.Add(mapper.Map<Person, PersonDTO>(p)));
            logger.LogInformation($"request for find with parametres: " + dto.toLog());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult create(PersonDTO dto)
        {
            logger.LogInformation($"request for create with parametres: " + dto.toLog());
            return Ok(mapper.Map<Person, PersonDTO>(service.create(mapper.Map<PersonDTO, CreationPersonArgument>(dto))));
        }

        [HttpPut]
        public IActionResult update(PersonDTO dto)
        {
            logger.LogInformation($"request for update with parametres: " + dto.toLog());
            return Ok(mapper.Map<Person,PersonDTO>(service.update(mapper.Map<PersonDTO, UpdatingPersonArgument>(dto))));
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int? id)
        {
            logger.LogInformation($"request for delete with parametres: " + id);
            service.deleteById(id);
            return Ok();
        }
        
        
    }
}
