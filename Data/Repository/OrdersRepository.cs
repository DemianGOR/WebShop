using System;
using System.Net;
using System.Net.Mail;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDBContent;
        private readonly ShopCart _shopCart;
        public uint sum;

        public OrdersRepository(AppDBContent _appDBContent, ShopCart _shopCart)
        {
            this._appDBContent = _appDBContent;
            this._shopCart = _shopCart;
        }
        public void CreateOrder(Order Order)
        {
            Order.OrderTime = DateTime.Now;
            _appDBContent.Order.Add(Order);
            _appDBContent.SaveChanges();

            var items = _shopCart.ListShopItems;
            sum = 0;
            foreach (var el in items)
            {
                sum += el.Price;
                var orderDetail = new OrderDetail()
                {
                    PhoneId = el.Phone.Id,
                    OrderId = Order.Id,
                    Price = el.Phone.Price
                };
                _appDBContent.OrderDetail.Add(orderDetail);
            }
            _appDBContent.SaveChanges();
            MailAddress from = new MailAddress("illia.voloshyn@nure.ua", "V-Shop");
            MailAddress to = new MailAddress(Order.Email);
            MailMessage m = new MailMessage(from, to);

            m.Subject = "Заказ";
            m.Body = $"<h2>Ваш заказ на сумму {sum} гривень успешно оформлен, забрать его вы можете в ближайшем пункте выдачи</h2>";
            m.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false; 
            smtp.Credentials = new NetworkCredential("illia.voloshyn@nure.ua", "1234ILya1234");
            smtp.Send(m);
        }
    }
}
