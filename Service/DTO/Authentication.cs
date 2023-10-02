using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class Authentication
    {
        public string Username { get; set; }
        public string Token { get; set; } 
        public string PhotoUrl { get; set; }
        public string KnownAS { get; set; }
        public string Gender { get; set; }
        
        
    }
}
