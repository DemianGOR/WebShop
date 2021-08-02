using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Data.Models
{
    public class Phone
    {

        public int Id { set; get; }
        [Required(ErrorMessage = "Не указан пароль")]
        
        public string Name { set; get; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string ShortDesc { set; get; }
    
        public string Img { set; get; }
        [Required(ErrorMessage = "Не указан пароль")]
        public uint Price { set; get; }
        [Required(ErrorMessage = "Не указан пароль")]
        public bool IsFavourite { set; get; }
        [Required(ErrorMessage = "Не указан пароль")]
        public bool Available { set; get; }
        
        public int CategoryID { set; get; }
        [Required(ErrorMessage = "Не указан пароль")]
        public virtual Category Category { set; get; }

    }
}
