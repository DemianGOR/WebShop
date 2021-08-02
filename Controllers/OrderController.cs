using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Controllers
{
    public class OrderController : Controller 
    {
        private readonly IAllOrders allOrders;
        private  ShopCart _shopCart;

        public OrderController(IAllOrders allOrders, ShopCart _shopCart)
        {
            this.allOrders = allOrders;
            this._shopCart = _shopCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopitems();
            if(_shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("","у вас должны быть товары в гробу!!!!");
            }
            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                _shopCart.ClearCart(_shopCart.ShopCartId);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {

            ViewBag.Message = "Гроб успешно запакован";
            return View();
        }
    }
}
    