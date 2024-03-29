﻿using System.ComponentModel.DataAnnotations;

namespace GamingAssistant
{
    public class AuthentificationModel
    {
        [Required(ErrorMessage = "Не может быть пустым")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_]+$", ErrorMessage = "Имя пользователя должно содержать только буквы латинского алфавита (в любом регистре), цифры и дефисы, подчеркивания\nПервый символ должен быть буквой")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Минимальная длина 2 символа")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Не может быть пустым")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Минимальная длина 4 символа")]
        [RegularExpression(@"^[a-zA-Z0-9!@#$%^&*]+$", ErrorMessage = "Пароль должен содержать только буквы латинского алфавита (в любом регистре), цифры и сиволы !@#$%^&*")]
        public string Password { get; set; }
    }
}
