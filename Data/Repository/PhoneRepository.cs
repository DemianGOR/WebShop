using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repository
{
    public class PhoneRepository : IAllPhones
    {
        private readonly AppDBContent appDBContent;

        public PhoneRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent; 
        }

        public IEnumerable<Phone> Phones => appDBContent.Phone.Include(c =>c.Category);

        public IEnumerable<Phone> GetFavPhones => appDBContent.Phone.Where(p => p.IsFavourite).Include(c => c.Category);

        public Phone GetobjectPhone(int PhoneID) => appDBContent.Phone.FirstOrDefault(p=>p.Id == PhoneID);

        public void  UpdatePhone (Phone phone)
        {
            
           var PhoneToUpdate = appDBContent.Phone.FirstOrDefault(p => p.Id ==phone.Id);
            appDBContent.Phone.Update(phone);
            appDBContent.SaveChanges();
        }
        public void RemovePhone(int Id)
        {
            var PhoneToRemove = appDBContent.Phone.FirstOrDefault(i => i.Id == Id);
            appDBContent.Phone.Remove(PhoneToRemove);
            appDBContent.SaveChanges();
        }
        public void AddPhone(Phone phone)
        {
            if (phone != null)
            {
                appDBContent.Phone.Add(phone);
            }
            if (phone != null)
            {
                appDBContent.SaveChanges();
            }

        }

        
    }
}
