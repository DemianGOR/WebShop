using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;
using WebShop.Data.Repository;
using WebShop.ViewModels;

namespace Web_Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private IAllPhones _phoneRep;
        private  ShopCart _shopCart;

        public ShopCartController(IAllPhones phoneRep, ShopCart shopCart)
        {
            _phoneRep = phoneRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopitems();
            _shopCart.ListShopItems = items;


            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };
            return View(obj);

        }
        public RedirectToActionResult AddToCart(int Id)
        {
            var item = _phoneRep.Phones.FirstOrDefault(i =>i.Id == Id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
                
            }
            return RedirectToAction("Index");
        }
       
        public RedirectToActionResult RemoveFromCart(int Id)
        {

                _shopCart.RemoveFromCart(Id);
            
            return RedirectToAction("Index");
        }

        private RedirectToActionResult ClearCart(char id)
        {
            return RedirectToAction("Index");
        }

    }
}
