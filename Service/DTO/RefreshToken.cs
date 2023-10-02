using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    internal class RefreshToken
    {
        public DateTime Expiration { get; set; }
        public bool IsExpire => DateTime.UtcNow >= Expiration;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsActive => RevokedOn == null && !IsExpire;
    }
}
