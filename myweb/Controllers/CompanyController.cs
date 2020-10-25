using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace myweb.Controllers
{
    [ApiController]
    [Route("api/v1.0/company")]
    public class CompanyController : Controller
    {
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View("Views/Company/Contact.cshtml");
        }
    }
}
