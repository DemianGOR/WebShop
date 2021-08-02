using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if (!content.Phone.Any())
            {


                content.AddRange(
                     new Phone
                     {
                         Name = "IphoneX",
                         ShortDesc = "Дорогой красивый телефон",
                         Img = "/img/XyiPhoneX.jpg",
                         Price = 27000,
                         IsFavourite = true,
                         Available = true,
                         Category = Categories["Iphone"]
                     },
                    new Phone
                    {
                        Name = "MeizuM3s",
                        ShortDesc = "дешевый,доступный телефон",
                        Img = "/img/ManPhone.jpg",
                        Price = 3000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Meizu"]
                    },
                    new Phone
                    {

                        Name = "Meizu Redmi 9C 2/32Gb ",
                        ShortDesc = "дешевый,доступный телефон",
                        Img = "/img/Meizu3.jpg",
                        Price = 6000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Meizu"]
                    },
                    new Phone
                    {

                        Name = "Meizu Redmi Note 9 Pro 6/128Gb",
                        ShortDesc = "дешевый,доступный телефон",
                        Img = "/img/Meizu2.jpg",
                        Price = 9000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Meizu"]
                    },
                    new Phone
                    {

                        Name = "Apple iPhone 12 64GB PRODUCT Red",
                        ShortDesc = "дорого и не стоит этих денег",
                        Img = "/img/Iphone red.jpg",
                        Price = 35000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Iphone"]
                    },
                    new Phone
                    {

                        Name = "Apple iPhone 12 Pro 128GB Gold ",
                        ShortDesc = "крайне дорогоБзачем тебе это?",
                        Img = "/img/Iphone 12.jpg",
                        Price = 40000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Iphone"]
                    }

            );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {

            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{CategoryName="Iphone",Desc="Самый популярный бренд"},
                        new Category{CategoryName="Meizu",Desc="Бюджетные телефоны" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.CategoryName, el);
                    }

                }
                return category;
            }
        }
    }
}
