using HappyPath.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyPath.Controllers
{
    public class HomeController : Controller
    {
        readonly IPersonService _personService;
        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public ActionResult Index()
        {
            var person = _personService.GetPersonByName("Jason");

            ViewBag.Message = String.Format("Person: {0} {1}", person.FirstName, person.LastName);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
