using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
         
        public List<ShopCartItem > ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services )
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
             
            return new ShopCart(context) { ShopCartId = shopCartId };               
        }   
        public void AddToCart(Phone Phone )
        {
            appDBContent.ShopCartItem.Add
                (new ShopCartItem
                 {
                ShopCartId =ShopCartId,
                Phone=Phone,
                Price=Phone.Price
                 });
            appDBContent.SaveChanges();
        }
        public void RemoveFromCart(int Id)
        {
            var itemToRemove = appDBContent.ShopCartItem.FirstOrDefault(i => i.Id == Id);
            appDBContent.ShopCartItem.Remove(itemToRemove);
            appDBContent.SaveChanges();
        }
        public List<ShopCartItem> GetShopitems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Phone).ToList();
        }

        public void ClearCart(string Id)
        {
            var itemsToRemove = appDBContent.ShopCartItem.Where(c => c.ShopCartId == Id);
            foreach (var item in itemsToRemove)
            {
                appDBContent.ShopCartItem.Remove(item);

            }
            appDBContent.SaveChanges();
        }
    }
}
