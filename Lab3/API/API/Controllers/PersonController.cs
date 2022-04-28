using API.PersonData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Collections.Generic;

namespace API.Controllers
{

    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPerson _personData;

        public PersonController(IPerson personData)
        {
            _personData = personData;
        }
        
        [HttpGet]
        [Route("api/persons")]
        public IActionResult GetPersons()
        {
            return Ok(_personData.GetPersons());
        }

        [HttpGet]
        [Route("api/person/{personId}")]
        public IActionResult GetPerson(int personId)
        {
            var person = _personData.GetPerson(personId);

            if (person != null)
            {
                return Ok(person);
          
            }

            return NotFound($"Person with {personId} not found!");

        }

        [HttpGet]
        [Route("api/person/links/{personId}")]
        public IActionResult GetLinks(int personId)
        {
            var linkList = _personData.GetLinks(personId);

            if (linkList != null)
            {
                return Ok(linkList);

            }

            return NotFound($"Person with {personId} not found!");

        }

        [HttpPost]
        [Route("api/person/update/interest/{personId}")]
        public IActionResult UpdateInterest(int personId, Intresse interest)
        {
            var existingPerson = _personData.GetPersonById(personId);

            if (existingPerson != null)
            {
                _personData.UpdatePersonInterest(existingPerson, interest);
                return Ok("GG");
            }
            return NotFound($"Person with {personId} not found!");
        }

        
        [HttpPost]
        [Route("api/person/update/link/{personId}/{interestId}")]
        public IActionResult UpdateLinks(int personId, int interestId, List<Links> link)
        {
            var existingPerson = _personData.GetPersonById(personId);

            if (existingPerson != null)
            {
                foreach(var linkitem in link)
                {
                    _personData.UpdatePersonLink(existingPerson, interestId, linkitem);
                }

                return Ok("gg");
            }
            return NotFound($"Person with {personId} not found!");
        }

    }
}
