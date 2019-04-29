using System.ComponentModel.DataAnnotations;

namespace GamingAssistant
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_]+$", ErrorMessage = "The username must contain only letters of the Latin alphabet (in any case), numbers, and hyphens/underscores\nThe first symbol must be a letter")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Минимальная длина 2 символа")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Минимальная длина 4 символа")]
        [RegularExpression(@"^[a-zA-Z0-9!@#$%^&*]+$", ErrorMessage = "The password must contain only letters of the Latin alphabet (in any case), numbers, and symbols !@#$%^&*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
    }
}
