using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Controllers
{
    public class ModalController : Controller
    {
        private readonly IAllPhones _allphones;
        private readonly IPhonesCategory _allcategories;

     
        public ModalController(IAllPhones iAllPhones, IPhonesCategory iPhonesCat)
        {
            _allphones = iAllPhones;
            _allcategories = iPhonesCat;
        }
        public ActionResult Index()
        {
            return View(_allphones.Phones);
        }
        public ActionResult Details(int id)
        {

            Phone c = _allphones.Phones.First(com => com.Id == id);
            if (c != null)
                return PartialView(c);
            return null;
        }
    }
}
