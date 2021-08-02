using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;
using WebShop.ViewModels;

namespace Web_Shop.Controlers
{
    public class PhonesController : Controller
    {
        private readonly IAllPhones _allphones;
        private readonly IPhonesCategory _allcategories;

        public PhonesController(IAllPhones iAllPhones, IPhonesCategory iPhonesCat)
        {
            _allphones = iAllPhones;
            _allcategories = iPhonesCat;
        }
        [Route("Phones/List")]
        [Route("Phones/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Phone> Phones = null;
            string CurrentCategory="";
            if (string.IsNullOrEmpty(category))
            {
                Phones = _allphones.Phones.OrderBy(i => i.Id);  
            }
            else
            {
                if (string.Equals("iphone", category, StringComparison.OrdinalIgnoreCase))
                {
                    Phones = _allphones.Phones.Where(i => i.Category.CategoryName.Equals("Iphone")).OrderBy(i => i.Id);
                    CurrentCategory = "Яблоки";
                }
                else if (string.Equals("meizu", category, StringComparison.OrdinalIgnoreCase))
                {
                    Phones = _allphones.Phones.Where(i => i.Category.CategoryName.Equals("Meizu")).OrderBy(i => i.Id);
                    CurrentCategory = "Нормльные телефоны";
                }
                
            }
            var pobj = new PhonesListViewModel
            {
                AllPhones = Phones,
                CurrentCategory = CurrentCategory

            };
            ViewBag.Title = "Page with phones";
            return View(pobj);
        }
    }
}
