
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class RegisterDto
    {
        [Required (ErrorMessage ="Name can't be blank")]
        public string Username { get; set; } = null!;
        [Required]
        public DateTime? Dateofbirth { get; set; }
        [Required]
        public string Knownas { get; set; } = null!;
        [Required]
        public string Gender { get; set; } = null!;
        public string City { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "Password can't be blank")]
        [StringLength(8,MinimumLength =4)]
        public string password { get; set; } = null!;
     
    }
}
