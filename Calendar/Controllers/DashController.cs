using Calendar.BusinessLayer;
using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calendar.Controllers
{
    public class DashController : Controller
    {
        // GET: Dash
        public ActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();
            IBusinessDash businessDash = new BusinessDash();




            employeeList = businessDash.employees();
                return View(employeeList);
        }

        public ActionResult Edit(Employee employeeEdit)
        {
            return View(employeeEdit);
        }
    }
}