using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myweb.Models;
using myweb.Services.Interfaces;
using Newtonsoft.Json;

namespace myweb.Controllers
{
    [ApiController]
    [Route("api/v1.0/Users")]
    public class UserController : Controller
    {
        private readonly IUserRepository repo;
        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("loginData")==null)
            {
                return View("Views/User/Login.cshtml");
            }
            return RedirectToAction("Main", "Product");
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> Login([FromForm]User user)
        {
            User result = await repo.GetUser(user);
            if (result != null)
            {
                HttpContext.Session.SetString("loginData", JsonConvert.SerializeObject(result));
            }
            return RedirectToAction("Main", "Product");
        }

        [HttpGet]
        [Route("LogOut")]
        public IActionResult LogOut()
        {
            if (HttpContext.Session.GetString("loginData") != null)
            {
                HttpContext.Session.Remove("loginData");
            }
            return RedirectToAction("Login");
        }
    }
}
