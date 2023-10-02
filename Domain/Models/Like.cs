using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Like
    {
        public decimal Id { get; set; }
        public decimal? Sourceuserid { get; set; }
        public decimal? Targetuserid { get; set; }

        public virtual User? Sourceuser { get; set; }
        public virtual User? Targetuser { get; set; }
    }
}
