using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieListCore3.Controllers
{
    public class AppointmentController : Controller
    {
        
        public IActionResult Index()
        {
            
            //string todays = DateTime.Now.ToShortDateString();
            //return Ok(todays);
            return View();

        }

        [HttpPost]
        public ContentResult AjaxMethod(string name)
        {
            string currentDateTime = string.Format("Hello {0}.\nCurrent DateTime: {1}", name, DateTime.Now.ToString());
            return Content(currentDateTime);
        }
    }
}
