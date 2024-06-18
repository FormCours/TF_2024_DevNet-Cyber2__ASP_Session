using System.ComponentModel.DataAnnotations;

namespace DemoAppWeb_Session.Models
{
    public class MemberLoginForm
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class MemberRegisterForm
    {
        [Required, MinLength(2)]
        public string Username { get; set; }

        [Required, MinLength(8)]
        [RegularExpression("/^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[^0-9a-zA-Z]).+$/")]
        public string Password { get; set; }

        [Required, Compare(nameof(Password))]
        public string PasswordCheck { get; set; }

        [Required, MinLength(2)]
        public string Firstname { get; set; }

        [Required, MinLength(2)]
        public string Lastname { get; set; }

    }
}
