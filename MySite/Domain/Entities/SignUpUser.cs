
using System.ComponentModel.DataAnnotations;

namespace MySite.Domain.Entities
{
    public class SignUpUser 
    {
       

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите e-mail")]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "Некорректный ввод")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Compare("ConfirmPassword", ErrorMessage = "Пароль на совпадает")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
