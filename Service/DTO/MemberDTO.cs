using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public  class MemberDTO
    {
        public decimal Id { get; set; }
        public string? Username { get; set; }
        public string PhotoUrl { get; set; } //for main photo in note book you find the way to make mapper know it 
        public int Age { get; set; }
         
        public string? Knownas { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Lastactive { get; set; }
        public string? Gender { get; set; }
        public string? Introduction { get; set; }
        public string? Lookingfor { get; set; }
        public string? Interests { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<PhotoDTO> Photos { get; set; }



    }
   
}
