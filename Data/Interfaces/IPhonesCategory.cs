using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface IPhonesCategory
    {
        IEnumerable<Category> AllCategories { get;  }
    }
}
