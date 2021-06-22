using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTimeTracking.Models;
using WebTimeTracking.Services;

namespace WebTimeTracking.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Regist(Person model)
        {
            if (ModelState.IsValid)
            {
                string sValidationMsg;
                sValidationMsg = DataValidation.IsPersonValid(ref model);
                if (sValidationMsg.Equals(string.Empty))
                    return RedirectToAction("Index", "Home");
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
