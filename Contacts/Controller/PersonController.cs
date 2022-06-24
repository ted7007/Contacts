using Contacts.DTO;
using Contacts.Mapper;
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

        public PersonController(IPersonService service)
        {
            db = service;
            mapper = new PersonMapper();
        }


        private PersonMapper mapper;

        [HttpGet]
        public ActionResult findAll()
        {
            var result = new List<PersonDTO>();
            db.findAll().ToList().ForEach(p => result.Add(mapper.EntityToDTO(p)));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult find(int id)
        {
            var result = db.find(id);
            if (result is null)
                return BadRequest($"No person with id: {id}");
            return Ok(mapper.EntityToDTO(result));
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
            if (dto.id is null)
                return BadRequest("No id in request.");
            var user = db.find(dto.id);
            if (user == null)
                return BadRequest($"Person with id: {dto.id} is not found");
            return Ok(db.update(mapper.DTOToEntity(dto)));
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int? id)
        {
            var user = db.find(id);
            if (user == null)
                return BadRequest($"Person with id: {id} is not found");
            db.delete(id);
            return Ok();
        }

        [HttpGet("sort")]
        public IActionResult sort(string sortState)
        {
            var result = db.findAllAndSort(mapper.stringToPersonSortState(sortState));
            return Ok(result);
        }

        // todo: сортировка, ошибки, чекать докер
    }
}
