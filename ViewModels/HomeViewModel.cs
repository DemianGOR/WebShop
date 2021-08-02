using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Models;

namespace WebShop.ViewModels
{
    public class HomeViewModel 
    {
        public IEnumerable<Phone> FavPhones { get; set; }
    }
}
