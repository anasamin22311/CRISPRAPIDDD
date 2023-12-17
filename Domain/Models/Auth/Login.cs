using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Auth
{
    public class Login
    {
        [Required, StringLength(128)]
        public string UserName { get; set; }
        [Required, StringLength(256)]
        public string Password { get; set; }
    }
}