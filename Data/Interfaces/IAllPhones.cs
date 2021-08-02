using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface IAllPhones
    {
     IEnumerable<Phone> Phones { get; }

     IEnumerable<Phone> GetFavPhones { get; }

     Phone GetobjectPhone(int PhoneID);
        void UpdatePhone(Phone phone);

        void RemovePhone(int Id);
        void AddPhone(Phone phone);

    }
}
