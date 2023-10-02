using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username can't be blank")]
        
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Password can't be blank")]
        public string Password { get; set; } = null!;
    }
}
