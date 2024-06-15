using BuffBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuffBlog.Controllers
{
    public class UserController:Controller
    {
        public IActionResult Login(){
            return View("Login");
        }
        [HttpGet]
         public IActionResult Register(){
            return View("Register");
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model){
            if(ModelState.IsValid){
                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}