using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDBContent _appDBContent;
        private IAllPhones _phoneRep;
        private IPhonesCategory _categoryRep;
        public AdminController(IAllPhones phoneRep, IPhonesCategory categoryRep)
        {
            this._phoneRep = phoneRep;
            this._categoryRep = categoryRep;
        }
        public IActionResult Index()
        {
            return View();
        }

        public RedirectToActionResult RemoveFromStore(int Id)
        {

            _phoneRep.RemovePhone(Id);

            return RedirectToAction("Index");
        }

        public IActionResult AddToStore()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToStore( Phone phone)
        {




                Phone chekphone =  _phoneRep.Phones.FirstOrDefault(p => p.Name == phone.Name);
               // if (chekphone == null)
                //{
                  //  while (phone.Name == null && phone.ShortDesc == null)
                  //  {
                        // добавляем пользователя в бд
                        var newPhone = new Phone
                        {
                            Name = phone.Name,
                            Price = phone.Price,
                            Available = phone.Available,
                            IsFavourite = phone.IsFavourite,
                            ShortDesc = phone.ShortDesc,
                            Category = _categoryRep.AllCategories.Where(c=>c.CategoryName==phone.Category.CategoryName).FirstOrDefault()
                        };
                        if (phone.Name != null && phone.ShortDesc != null)
                        {
                            _phoneRep.AddPhone(newPhone);
                        }
                  //  }
                    

                
                return RedirectToAction("Index");

        }
    }
}
