using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTimeTracking.Data;
using WebTimeTracking.Models;
using WebTimeTracking.Services;
using WebTimeTracking.ViewModels;

namespace WebTimeTracking.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : Controller
    {
        private readonly ITrackingRepository _repository;
        public PersonController(ITrackingRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var person = _repository.GetPersonByID(id);
                if (person != null)
                {
                    PersonSimplyViewModel personView = new PersonSimplyViewModel()
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Emial = person.Emial,
                        Address = person.Address,
                        City = person.City,
                        PostalCode = person.PostalCode,
                        Country = person.Country
                    };
                    return Ok(personView);
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception ex)
            {
                return BadRequest($"Failed to return orders");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Person model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //TODO: Dodac AutoMappera
                    PersonViewModel person = new PersonViewModel() {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Emial = model.Emial,
                        Country = model.Country,
                        PostalCode = model.PostalCode,
                        City = model.City,
                        Address = model.Address,
                        Password = model.Password,
                        PasswordConfirm = model.Password
                    };
                    string validationMsg = DataValidation.IsPersonValid(ref person);
                    if (validationMsg.Equals(string.Empty))
                    {
                        _repository.AddPerson(model);
                        _repository.SaveAll();

                        return Created($"/api/orders/{model.PersonId}", model);
                    }
                    else
                    {
                        return BadRequest(validationMsg);
                    }

                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to save new order.");
            }
        }
    }
}
