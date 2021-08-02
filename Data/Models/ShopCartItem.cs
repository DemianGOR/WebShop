namespace WebShop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }

        public Phone Phone { get; set; }

        public uint Price { get; set; }

        public string ShopCartId { get; set;}
    }
}
