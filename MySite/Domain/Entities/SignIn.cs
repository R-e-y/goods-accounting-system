using System.ComponentModel.DataAnnotations;

namespace MySite.Domain.Entities
{
    public class SignIn
    {
        [Required(ErrorMessage = "Введите e-mail"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}
