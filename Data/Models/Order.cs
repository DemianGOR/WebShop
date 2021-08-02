using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите Имя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длинна имени должна составлять больше 2 символов")]
        [Required(ErrorMessage = "Введите Имя")]
        public string Name { get; set; }

        [Display(Name = "Введите Фамилию")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длинна номера не менее 3 символов, не более  20ти")]
        [Required(ErrorMessage = "Введите Фамилию")]
        public string Surname { get; set; }

        [Display(Name = "Введите Адресс")]
        [StringLength(40, MinimumLength = 7, ErrorMessage = "Введите коректный Адресс")]
        [Required(ErrorMessage = "Введите Адресс")]
        public string Adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(14, MinimumLength = 10, ErrorMessage = "Некоректный номер телефона")]
        [RegularExpression(@"((\+38|8|\+3|\+ )[ ]?)?([(]?\d{3}[)]?[\- ]?)?(\d[ -]?){6,14}", ErrorMessage = "Некоректный номер телефона")]
        [Required(ErrorMessage = "Некоректный номер телефона")]
        public string Phone { get; set; }

        [Display(Name = "Введите Имейл")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> Details { get; set; }
    }

}
