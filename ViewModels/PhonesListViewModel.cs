using System.Collections.Generic;
using WebShop.Data.Models;

namespace WebShop.ViewModels
{
    public class PhonesListViewModel
    {
        public IEnumerable<Phone> AllPhones { get; set; }
        public string CurrentCategory { get; set; }
    }
}
