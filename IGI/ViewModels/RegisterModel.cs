using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.ViewModels
{
    public class RegisterModel
    {
        [Display(Name = "Никнейм")]
        [Required(ErrorMessage = "Не указан Username")]
        public string Username { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Не указано Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Не указана Фамиля")]
        public string Surname { get; set; }

        [Display(Name = "Возраст")]
        [Range(1, 110, ErrorMessage = "Недопустимый возраст")]
        [Required(ErrorMessage = "Не указан возраст")]
        public byte Age { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Не указана страна")]
        public string Country { get; set; }

        [Display(Name = "Фотография")]
        public IFormFile Avatar { get; set; }

        [Display(Name = "Почта")]
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Повторите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
