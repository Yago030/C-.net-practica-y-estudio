﻿using backend2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

         private IPeopleService _peopleService;
            
         public PeopleController([FromKeyedServices("people2Service")]IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }


        [HttpGet("all")]
        public List<People> GetPeople() =>Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id) { // esto es bueno para cuando pueden haber respuestas inesperadas
        
        var people = Repository.People.FirstOrDefault(p => p.Id == id); //funcion de primer orden, recorre todo el listado y nos trae la de la primera coincidencia

        if (people == null)
            {
                return NotFound();
            }

        return Ok(people);

        }

        


        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public  IActionResult  Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.People.Add(people);

            return NoContent(); // FUNCIONO BIEN pero no regreso info al body , Y FUE EXITOSO EL ENVIO DE INFO

        }
    }
        
   
    public class Repository
    {
        public static List<People> People = new List<People>
     {
        new People()
        {
            Id = 1, Name = "Pedro", Birthdate = new DateTime(1990, 12, 03)
        },
        new People()
        {
            Id = 2, Name = "Luis", Birthdate = new DateTime(1990, 02, 13)
        },
        new People()
        {
            Id = 3, Name = "Ana", Birthdate = new DateTime(1990, 11, 23)
        },
        new People()
        {
            Id = 4, Name = "Hugo", Birthdate = new DateTime(1990, 04, 13)
        },
        new People()
        {
            Id = 5, Name = "Analaura", Birthdate = new DateTime(1997, 09, 23)
        },
      }; 
    }



    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

    }

};
