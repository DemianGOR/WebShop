using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebShop.Data.Interfaces;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private IAllPhones _phoneRep;

        public HomeController(IAllPhones phoneRep)
        {
            _phoneRep = phoneRep;
        }


        public ViewResult Index()
        {
            var HomePhones = new HomeViewModel
            {
                FavPhones = _phoneRep.GetFavPhones
            };
            return View(HomePhones);
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Client()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return Content($"ваша роль: {role}");
        }
        [Authorize(Roles = "admin")]
        public IActionResult About()
        {
            return Content("Вход только для администратора");
        }
    }
}
