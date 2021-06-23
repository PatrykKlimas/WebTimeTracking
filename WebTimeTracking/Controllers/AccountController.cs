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
    public class AccountController : Controller
    {
        private readonly ITrackingRepository _repository;
        public AccountController(ITrackingRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Regist(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                string sValidationMsg;
                sValidationMsg = DataValidation.IsPersonValid(ref model);
                if (sValidationMsg.Equals(string.Empty))
                {

                    Person person = new Person
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Emial = model.Emial,
                        Address = model.Address,
                        City = model.City,
                        PostalCode = model.PostalCode,
                        Country = model.Country,
                        Password = model.Password                        
                    };
                   // _repository.AddPerson(person);
                    //_repository.SaveAll();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", sValidationMsg);
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult Regist()
        {
            return View();
        }
    }
}
