using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingDemonstration_1.Models;

namespace UnitTestingDemonstration_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Employee emp = new Employee
            {
                Id=101,Name="Abhishek",Location="Bangalore",Salary=12345
            };

            ViewBag.testName = "Pragim Tech";

            return View("TestView",emp);

            //return RedirectToAction("Home");
        }
    }
}