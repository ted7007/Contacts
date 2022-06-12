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
            return Ok(mapper.EntityToDTO(db.find(id)));
        }

        [HttpPost]
        public IActionResult create(PersonDTO dto)
        {
            return Ok(mapper.EntityToDTO(db.create(mapper.DTOToCreationArgument(dto))));
        }


    }
}
